using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Account_Repo : Main_Repo<Account>
    {
        public Account_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Account>> GetAllUserAccounts(int userID) => await _dbContext.Accounts.Where(x => x.UserID == userID).ToListAsync();

        public async Task<bool> VerifyCBUUnicity(string cbu)
        {
            int sameCBU = await _dbContext.Accounts.Where(x => x.CBU == cbu).CountAsync();
            return sameCBU == 0;
        }

        public async Task<bool> VerifyUUIDUnicity(string uuid)
        {
            int sameUUID = await _dbContext.Accounts.Where(x => x.UUID == uuid).CountAsync();
            return sameUUID == 0;
        }

        public async Task<bool> UpdateAccountBalance(int id, string operation, decimal amount)
        {
            var accountToUpdate = await _dbContext.Set<Account>().FindAsync(id);

            if(accountToUpdate != null)
            {
                _ = operation == "+" ? accountToUpdate.Balance += amount : accountToUpdate.Balance -= amount;
                return true;
            }

            return false;
        }
    }
}
