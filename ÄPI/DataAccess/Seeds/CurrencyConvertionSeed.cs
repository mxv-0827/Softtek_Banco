using ÄPI.Entities;
using ÄPI.Services.APIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class CurrencyConvertionSeed : IEntityTypeConfiguration<CurrencyConvertion>
    {
        public void Configure(EntityTypeBuilder<CurrencyConvertion> builder)
        {
            builder.HasData(
                new CurrencyConvertion { ID = 1, From_Currency = 1, To_Currency = 2, Price = ConvertCurrency("ARS", "USD").Result },
                new CurrencyConvertion { ID = 2, From_Currency = 1, To_Currency = 3, Price = ConvertCurrency("ARS", "BTC").Result },
                new CurrencyConvertion { ID = 3, From_Currency = 2, To_Currency = 1, Price = ConvertCurrency("USD", "ARS").Result },
                new CurrencyConvertion { ID = 4, From_Currency = 2, To_Currency = 3, Price = ConvertCurrency("USD", "BTC").Result },
                new CurrencyConvertion { ID = 5, From_Currency = 3, To_Currency = 1, Price = ConvertCurrency("BTC", "ARS").Result },
                new CurrencyConvertion { ID = 6, From_Currency = 3, To_Currency = 2, Price = ConvertCurrency("BTC", "USD").Result }
                );
        }

        private async Task<decimal> ConvertCurrency(string fromCurrency, string toCurrency) //Used as references convertion values.
        {
            return await CurrencyConvertionAPI.GetCurrencyConvertion(fromCurrency, toCurrency, 1);
        }
    }
}
