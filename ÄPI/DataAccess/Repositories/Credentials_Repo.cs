using ÄPI.DTOs;
using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Credentials_Repo : Main_Repo<Credentials>
    {
        public Credentials_Repo(ApplicationDBContext dbContext) : base(dbContext) { }

        public async Task<object?> AuthenticateCredentials(LoginDTO credentials)
        {
            var correctCredentials = await _dbContext.Credentials.SingleOrDefaultAsync(x => x.Email == credentials.Email && x.Password == credentials.Password);

            return correctCredentials == null ? throw new Exception("Incorrect credentials.") : correctCredentials;
        }
    }
}
