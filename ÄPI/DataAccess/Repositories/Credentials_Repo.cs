using ÄPI.DTOs;
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

        public async Task UpdateCredentials(LoginDTO credentials)
        {
            throw new NotImplementedException();
            //In case of use of this method, password must be updated with the new email (in case, that is the updated prop)
        }
    }
}
