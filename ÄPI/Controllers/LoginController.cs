using ÄPI.DTOs;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JWT_Helper _token;
        private readonly IUnitOfWork _unitOfWork;


        public LoginController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _token = new JWT_Helper(configuration);
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginCredentials)
        {
            try
            {
                var userCredentials = await _unitOfWork.CredentialsRepo.AuthenticateCredentials(loginCredentials);

                if (userCredentials != null)
                {
                    var credentials = (Credentials)userCredentials;
                    int userID = credentials.ID;

                    return Ok(_token.GenerateToken(userID));
                }

                return BadRequest("Something went wrong.");
            }
            
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
