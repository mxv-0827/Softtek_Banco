using ÄPI.Entities;
using ÄPI.Infrastructure.CustomExceptions;
using ÄPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public AccountTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets every single accountType created in the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAccountTypes")]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            try
            {
                List<AccountType> fullAccountTypes = await _unitOfWork.AccountTypeRepo.GetAllEntities(); //Gets the full accountType entity.

                List<string> accountTypes = new List<string>();

                foreach (AccountType accountType in fullAccountTypes)
                {
                    accountTypes.Add(accountType.Description); //Adds only the currency name to the list.
                }

                return ResponseFactory.CreateSuccessResponse(202, accountTypes);
            }

            catch(Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}
