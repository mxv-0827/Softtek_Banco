using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class AccountTypeCurrency_Repo : Main_Repo<AccountType_Currency>
    {
        public AccountTypeCurrency_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<AccountType_Currency>> GetAvailableCurrencies(int accountTypeID) => await _dbContext.Set<AccountType_Currency>().Where(x => x.AccountTypeID == accountTypeID).ToListAsync();
        

    }

}
