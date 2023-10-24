using ÄPI.DTOs.Account;
using ÄPI.DTOs.Transaction;
using ÄPI.Entities;
using ÄPI.Helpers;
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


        [HttpPost("AddTransaction")]
        public async Task<ActionResult> AddTransaction(TransactionAdd_DTO addTransaction)
        {
            var transactionProcess = _unitOfWork.BeginTransaction(); //Initializes transaction.

            try
            {
                var originAccount = addTransaction.OriginAccountID != null ? await _unitOfWork.AccountRepo.GetEntityById((int)addTransaction.OriginAccountID) : null;
                var destinationAccount = addTransaction.DestinationAccountID != null ? await _unitOfWork.AccountRepo.GetEntityById((int)addTransaction.DestinationAccountID) : null;


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
                        return Ok("Transaction successfully uploaded."); //In case of an EXTRACTION.
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

                        return Ok("Transactions successfully uploaded.");
                    }
                }

                else
                {
                    await _unitOfWork.TransactionRepo.AddEntity(transaction);
                    await _unitOfWork.Save();

                    await _unitOfWork.AccountRepo.UpdateAccountBalance(destinationAccount.AccountNumber, "+", transaction.Amount); //Amount already converted.
                    await _unitOfWork.Save(); //In case of a DEPOSIT.

                    await transactionProcess.CommitAsync(); //Confirms changes into the DB => END OF ROUTE.
                    return Ok("Transaction successfully uploades.");
                }
            }

            catch (Exception ex)
            {
                await transactionProcess.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAccountTransactions")]
        public async Task<ActionResult<IEnumerable<TransactionGet_DTO>>> GetAccountTransactions(int accountNumber)
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

                return Ok(accountTransactions);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
