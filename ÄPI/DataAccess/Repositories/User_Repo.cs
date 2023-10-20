using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ÄPI.DataAccess.Repositories
{
    public class User_Repo : Main_Repo<User>
    {
        public User_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> ObtainUserId(int dni) 
        {
            var userFound = await _dbContext.Users.Where(user => user.DNI == dni).FirstOrDefaultAsync();
            return userFound.ID;
        }
    }
}
