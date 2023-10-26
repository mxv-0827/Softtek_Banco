using ÄPI.Entities;
using ÄPI.Services.APIs;
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

        public async Task<bool> UpdateCurrencyPrice(CurrencyConvertion currencyConvertion, string fromCurrencyName, string toCurrencyName)
        {
            var currencyCovertionRegister = await _dbContext.Set<CurrencyConvertion>().Where(x => x.From_Currency == currencyConvertion.From_Currency && x.To_Currency == currencyConvertion.To_Currency).FirstAsync();
            currencyConvertion.Price = await CurrencyConvertionAPI.GetCurrencyConvertion(fromCurrencyName, toCurrencyName, 1);

            return true;
        }
    }
}
