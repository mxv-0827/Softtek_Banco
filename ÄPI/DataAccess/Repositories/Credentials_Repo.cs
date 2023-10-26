using ÄPI.DTOs;
using ÄPI.DTOs.Credentials;
using ÄPI.Entities;
using ÄPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Credentials_Repo : Main_Repo<Credentials>
    {
        public Credentials_Repo(ApplicationDBContext dbContext) : base(dbContext) { }

        public async Task<object?> AuthenticateCredentials(LoginDTO credentials)
        {
            var correctCredentials = await _dbContext.Credentials.SingleOrDefaultAsync(x => x.Email == credentials.Email && x.Password == PasswordEncrypter_Helper.EncryptPassword(credentials.Password, credentials.Email));

            return correctCredentials ?? throw new Exception("Incorrect credentials.");
        }


        public async Task<int> UpdatePassword(CredentialsUpdate_DTO newCredentials)
        {
            var userCredentials = await _dbContext.Set<Credentials>().Where(x => x.Email == newCredentials.Email).FirstOrDefaultAsync();

            if(userCredentials != null)
            {
                userCredentials.Password = PasswordEncrypter_Helper.EncryptPassword(newCredentials.NewPassword, newCredentials.Email);
                return userCredentials.ID;
            }

            throw new Exception("The introduced email does not exist in DB.");
        }
    }
}
