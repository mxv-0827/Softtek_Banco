using ÄPI.Entities;
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


        [HttpGet("GetAllAccountTypes")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAccountTypes()
        {
            try
            {
                List<AccountType> fullAccountTypes = await _unitOfWork.AccountTypeRepo.GetAllEntities(); //Gets the full accountType entity.

                List<string> accountTypes = new List<string>();

                foreach (AccountType accountType in fullAccountTypes)
                {
                    accountTypes.Add(accountType.Description); //Adds only the currency name to the list.
                }

                return Ok(accountTypes);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
