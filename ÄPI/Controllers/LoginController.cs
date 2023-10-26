using ÄPI.DTOs;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Infrastructure.CustomExceptions;
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


        /// <summary>
        /// Authenticate the credentials of a user, in order to give him access to the website.
        /// </summary>
        /// <param name="loginCredentials"></param>
        /// <returns>A valid token used to access the website.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginCredentials)
        {
            try
            {
                if (!ModelState.IsValid) { } 

                var userCredentials = await _unitOfWork.CredentialsRepo.AuthenticateCredentials(loginCredentials);

                if (userCredentials != null)
                {
                    var credentials = (Credentials)userCredentials;
                    int userID = credentials.ID;

                    return ResponseFactory.CreateSuccessResponse(202, _token.GenerateToken(userID));
                }

                return ResponseFactory.CreateErrorResponse(500, "Unknown error took place while logging.");
            }
            
            catch(Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}
