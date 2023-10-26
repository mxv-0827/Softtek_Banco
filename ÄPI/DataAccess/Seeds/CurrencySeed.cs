using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class CurrencySeed : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(
                new Currency { ID = 1, Description = "ARS" },
                new Currency { ID = 2, Description = "USD" },
                new Currency { ID = 3, Description = "BTC" }
                );
        }
    }
}
