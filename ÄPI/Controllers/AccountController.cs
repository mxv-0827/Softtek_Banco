using ÄPI.DTOs.Account;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountAdd_DTO accountToAdd)
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

            if(accountToAdd.AccountType == "Fiduciary")
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
    }
}
