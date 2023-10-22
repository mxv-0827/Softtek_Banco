using ÄPI.DTOs.Credentials;
using ÄPI.Helpers;
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
        public async Task<ActionResult> UpdatePassword(CredentialsUpdate_DTO newCredentials)
        {
            try
            {
                var userID = await _unitOfWork.CredentialsRepo.UpdatePassword(newCredentials); //Returns the UserID from 'Credentials' in order to generate an authentication token.

                await _unitOfWork.Save();
                return Ok(_token.GenerateToken(userID));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
