using ÄPI.DTOs.Account;
using ÄPI.DTOs.Transaction;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Infrastructure.CustomExceptions;
using ÄPI.Services;
using ÄPI.Services.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Linq;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds a new transaction to DB.
        /// </summary>
        /// <param name="addTransaction">Object with the transaction props.</param>
        /// <returns>A message with rhe status of the process</returns>
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction(TransactionAdd_DTO addTransaction)
        {
            if (!ModelState.IsValid) { }

            var transactionProcess = _unitOfWork.BeginTransaction(); //Initializes transaction.

            try
            {
                if (addTransaction.OriginAccountID == addTransaction.DestinationAccountID) throw new Exception("Origin and destination account cannot have the same account number.");

                var originAccount = addTransaction.OriginAccountID != null ? await _unitOfWork.AccountRepo.GetEntityById((int)addTransaction.OriginAccountID) : null;
                var destinationAccount = addTransaction.DestinationAccountID != null ? await _unitOfWork.AccountRepo.GetEntityById((int)addTransaction.DestinationAccountID) : null;

                if (originAccount.UserID != destinationAccount.UserID) throw new Exception("Transfers can only be done among accounts from the same user.");

                Transaction transaction = new Transaction
                {
                    AccountID = addTransaction.OriginAccountID ?? (int)addTransaction.DestinationAccountID,
                    Type = addTransaction.TransactionType,
                    Amount = addTransaction.Amount
                };


                if(addTransaction.OriginAccountID != null) //Possible EXTRACTION or TRANSFER.
                {
                    decimal balance = originAccount.Balance;

                    if (balance < addTransaction.Amount) throw new Exception("Not enough funds to complete transaction."); 

                    await _unitOfWork.TransactionRepo.AddEntity(transaction);
                    await _unitOfWork.Save(); //Save the entity addition.

                    await _unitOfWork.AccountRepo.UpdateAccountBalance(originAccount.AccountNumber, "-", addTransaction.Amount); 
                    await _unitOfWork.Save(); //Save the entity modified balance.

                    if (addTransaction.DestinationAccountID == null) 
                    {
                        await transactionProcess.CommitAsync(); //Confirms changes into the DB. => END OF ROUTE.
                        return ResponseFactory.CreateSuccessResponse(201, "Extraction successfully uploaded.");//In case of an EXTRACTION.
                    } 
                    
                    else //In case of a TRANSFER.
                    {
                        Transaction transaction2 = new Transaction
                        {
                            AccountID = (int)addTransaction.DestinationAccountID,
                            Type = addTransaction.TransactionType,
                        };


                        //In case both currencies types are equal, then the amount remains the same since it does not need to be converted to another currency.
                        if (originAccount.CurrencyID == destinationAccount.CurrencyID) transaction2.Amount = addTransaction.Amount;

                        else
                        {
                            decimal amountConverted = await _unitOfWork.CurrencyConverted_Repo.ConvertBalance(originAccount.CurrencyID, destinationAccount.CurrencyID, addTransaction.Amount);
                            transaction2.Amount = amountConverted;
                        }

                        await _unitOfWork.TransactionRepo.AddEntity(transaction2);
                        await _unitOfWork.Save();

                        await _unitOfWork.AccountRepo.UpdateAccountBalance(destinationAccount.AccountNumber, "+", transaction2.Amount); //Amount already converted.
                        await _unitOfWork.Save();
                        await transactionProcess.CommitAsync(); //Confirms changes into the DB => END OF ROUTE.

                        return ResponseFactory.CreateSuccessResponse(201, "Transfer successfully uploaded.");
                    }
                }

                else
                {
                    await _unitOfWork.TransactionRepo.AddEntity(transaction);
                    await _unitOfWork.Save();

                    await _unitOfWork.AccountRepo.UpdateAccountBalance(destinationAccount.AccountNumber, "+", transaction.Amount); //Amount already converted.
                    await _unitOfWork.Save(); //In case of a DEPOSIT.

                    await transactionProcess.CommitAsync(); //Confirms changes into the DB => END OF ROUTE.
                    return ResponseFactory.CreateSuccessResponse(201, "Deposit successfully uploaded.");
                }
            }

            catch (Exception ex)
            {
                await transactionProcess.RollbackAsync();
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }


        /// <summary>
        /// Based on the accountNumber, get every single transaction.
        /// </summary>
        /// <param name="accountNumber"></param> //Object with the props required.
        /// <returns>Every transaction the account took part in.</returns>
        [HttpGet("GetAccountTransactions/{accountNumber}")]
        public async Task<IActionResult> GetAccountTransactions([FromRoute] int accountNumber)
        {
            try
            {
                List<Transaction> listAccountTransaction = await _unitOfWork.TransactionRepo.GetAllAccountsTransactions(accountNumber);

                List<TransactionGet_DTO> accountTransactions = new List<TransactionGet_DTO>();

                foreach (Transaction transaction in listAccountTransaction)
                {
                    accountTransactions.Add(new TransactionGet_DTO
                    {
                        TransactionNumber = transaction.ID,
                        AccountNumber = transaction.AccountID,
                        TransactionType = transaction.Type,
                        Amount = transaction.Amount
                    });
                }

                return ResponseFactory.CreateSuccessResponse(202, accountTransactions);
            }

            catch(Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}
