using ÄPI.DTOs.User;
using ÄPI.Entities;
using ÄPI.Helpers;
using ÄPI.Infrastructure.CustomExceptions;
using ÄPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private JWT_Helper _token;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _token = new JWT_Helper(configuration);
        }


        [HttpPost("AddFullUser")]
        public async Task<IActionResult> AddFullUser(UserAdd_DTO fullUser)
        {
            if (!ModelState.IsValid) { }

            var transaction = _unitOfWork.BeginTransaction();

            User user = new User
            {
                DNI = fullUser.DNI,
                Fullname = fullUser.FullName,
                BirthDate = fullUser.BirthDate,
                Genre = fullUser.Genre
            };

            try
            {
                bool statusAddUser = await _unitOfWork.UserRepo.AddEntity(user);

                if (statusAddUser)
                {
                    await _unitOfWork.Save();

                    Credentials credentials = new Credentials
                    {
                        ID = await _unitOfWork.UserRepo.ObtainUserId(fullUser.DNI),
                        Email = fullUser.Email,
                        Password = PasswordEncrypter_Helper.EncryptPassword(fullUser.Password, fullUser.Email)
                    };

                    bool statusAddCredentials = await _unitOfWork.CredentialsRepo.AddEntity(credentials);

                    if (statusAddCredentials)
                    {
                        await _unitOfWork.Save();
                        await transaction.CommitAsync();

                        return ResponseFactory.CreateSuccessResponse(201, _token.GenerateToken(credentials.ID));
                    }
                }

                return ResponseFactory.CreateErrorResponse(500, "An error took place while registering the user.");
            }
            
            catch(Exception ex)
            {
                transaction.Rollback();
                return ResponseFactory.CreateErrorResponse(404, ex.Message);
            }
        }
    }
}
