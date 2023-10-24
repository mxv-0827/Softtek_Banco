using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Transaction_Repo : Main_Repo<Transaction>
    {
        public Transaction_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Transaction>> GetAllAccountsTransactions(int accountNumber) => await _dbContext.Transactions.Where(x => x.AccountID == accountNumber).ToListAsync();
    }
}
