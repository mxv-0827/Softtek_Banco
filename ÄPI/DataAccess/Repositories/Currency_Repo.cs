using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Currency_Repo : Main_Repo<Currency>
    {
        public Currency_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetID(string currency)
        {
            var currencyFound = await _dbContext.Currencies.Where(x => x.Description == currency).FirstAsync();
            return currencyFound.ID;
        }
    }
}
