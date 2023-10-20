using ÄPI.DTOs.User;
using ÄPI.Entities;
using ÄPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ÄPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("AddFullUser")]
        public async Task<IActionResult> AddFullUser(UserAdd_DTO fullUser)
        {
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
                bool status1 = await _unitOfWork.UserRepo.AddEntity(user);

                if (status1)
                {
                    await _unitOfWork.Save();

                    Credentials credentials = new Credentials
                    {
                        ID = await _unitOfWork.UserRepo.ObtainUserId(fullUser.DNI),
                        Email = fullUser.Email,
                        Password = fullUser.Password
                    };

                    bool status2 = await _unitOfWork.CredentialsRepo.AddEntity(credentials);

                    if (status2)
                    {
                        await _unitOfWork.Save();
                        await transaction.CommitAsync();

                        return Ok("User full data successfully created");
                    }
                }

                return BadRequest("Something happened");
            }
            
            catch(Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
