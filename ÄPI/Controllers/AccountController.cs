using ÄPI.DTOs.Account;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private JWT_Helper _token;
        private IdentityAccountGenerator_Helper _generator;
        private readonly IUnitOfWork _unitOfWork;


        public AccountController(IConfiguration configuration, IUnitOfWork unitOfWork, IdentityAccountGenerator_Helper generator)
        {
            _token = new JWT_Helper(configuration);
            _unitOfWork = unitOfWork;
            _generator = generator;
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountAdd_DTO accountToAdd)
        {
            try
            {
                var authenticatedToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); //Obtains the token which was used to authenticate.

                Account account = new Account
                {
                    UserID = int.Parse(_token.GetUserIDFromToken(authenticatedToken)),
                    Alias = accountToAdd.Alias,
                    AccountTypeID = await _unitOfWork.AccountTypeRepo.GetID(accountToAdd.AccountType),
                    CurrencyID = await _unitOfWork.CurrencyRepo.GetID(accountToAdd.Currency),
                    Balance = 0,
                };

                if (accountToAdd.AccountType == "Fiduciary")
                {
                    bool uniqueCBU = false;

                    while (!uniqueCBU)
                    {
                        account.CBU = _generator.GenerateCBU();
                        uniqueCBU = await _unitOfWork.AccountRepo.VerifyCBUUnicity(account.CBU);
                    }

                    account.UUID = null;
                }

                else
                {
                    bool uniqueUUID = false;

                    while (!uniqueUUID)
                    {
                        account.UUID = _generator.GenerateUUID();
                        uniqueUUID = await _unitOfWork.AccountRepo.VerifyUUIDUnicity(account.UUID);
                    }

                    account.CBU = null;
                }

                await _unitOfWork.AccountRepo.AddEntity(account);
                await _unitOfWork.Save();

                return Ok("Everything went perfect.");
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("GetUserAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetUserAccounts()
        {
            var authenticatedToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); //Obtains the token which was used to authenticate.
            int userID = int.Parse(_token.GetUserIDFromToken(authenticatedToken));

            List<Account> listUserAccounts = await _unitOfWork.AccountRepo.GetAllUserAccounts(userID);

            List<AccountGet_DTO> userAccounts = new List<AccountGet_DTO>();

            foreach (Account account in listUserAccounts)
            {
                userAccounts.Add(new AccountGet_DTO
                {
                    AccountNumber = account.AccountNumber,
                    Alias = account.Alias,
                    AccountType = await _unitOfWork.AccountTypeRepo.GetAccountType(account.AccountTypeID),
                    Currency = await _unitOfWork.CurrencyRepo.GetCurrency(account.CurrencyID),
                    Balance = account.Balance,
                    CBU = account.CBU,
                    UUID = account.UUID
                });
            }

            return Ok(userAccounts);
        }


        [HttpGet("GetUserAccount/{accountNumber}")]
        public async Task<ActionResult> GetUserAccount([FromRoute] int accountNumber)
        {
            try
            {
                Account account = await _unitOfWork.AccountRepo.GetEntityById(accountNumber);

                AccountGet_DTO userAccountDTO = new AccountGet_DTO
                {
                    AccountNumber = account.AccountNumber,
                    Alias = account.Alias,
                    AccountType = await _unitOfWork.AccountTypeRepo.GetAccountType(account.AccountTypeID),
                    Currency = await _unitOfWork.CurrencyRepo.GetCurrency(account.CurrencyID),
                    Balance = account.Balance,
                    CBU = account.CBU,
                    UUID = account.UUID
                };

                return Ok(userAccountDTO);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetBalance/{accountNumber}")]
        public async Task<IActionResult> GetBalance([FromRoute] int accountNumber)
        {
            try
            {
                var authenticatedToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); //Obtains the token which was used to authenticate.
                int userID = int.Parse(_token.GetUserIDFromToken(authenticatedToken));

                var account = await _unitOfWork.AccountRepo.GetEntityById(accountNumber);

                if (userID != account.UserID) throw new Exception("This account does not belong to you.");
                
                return Ok(account.Balance);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
