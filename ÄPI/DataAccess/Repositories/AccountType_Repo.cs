using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class AccountType_Repo : Main_Repo<AccountType>
    {
        public AccountType_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetID(string accountType)
        {
            var accountTypeFound = await _dbContext.AccountTypes.Where(x => x.Description == accountType).FirstAsync();
            return accountTypeFound.ID;
        }
    }
}
