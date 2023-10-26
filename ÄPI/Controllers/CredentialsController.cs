using ÄPI.DTOs.Credentials;
using ÄPI.Helpers;
using ÄPI.Infrastructure.CustomExceptions;
using ÄPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private JWT_Helper _token;
        private readonly IUnitOfWork _unitOfWork;


        public CredentialsController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _token = new JWT_Helper(configuration);
        }


        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(CredentialsUpdate_DTO newCredentials)
        {
            try
            {
                if (!ModelState.IsValid) { }

                var userID = await _unitOfWork.CredentialsRepo.UpdatePassword(newCredentials); //Returns the UserID from 'Credentials' in order to generate an authentication token.
                await _unitOfWork.Save();

                return ResponseFactory.CreateSuccessResponse(202, _token.GenerateToken(userID));
            }

            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}
