using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class CurrencyConverted_Repo : Main_Repo<CurrencyConvertion>
    {
        public CurrencyConverted_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<decimal> ConvertBalance(int originCurrencyID, int destinationCurrencyID, decimal amount)
        {
            var convertionValue =  await _dbContext.CurrenciesConvertions.Where(x => x.From_Currency == originCurrencyID && x.To_Currency == destinationCurrencyID).FirstAsync();
            return convertionValue.Price * amount;
        }
    }
}
