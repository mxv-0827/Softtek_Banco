using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class AccountType_CurrencySeed : IEntityTypeConfiguration<AccountType_Currency>
    {
        public void Configure(EntityTypeBuilder<AccountType_Currency> builder)
        {
            builder.HasData(
                new AccountType_Currency { ID = 1, AccountTypeID = 1, CurrencyID = 1 },
                new AccountType_Currency { ID = 2, AccountTypeID = 1, CurrencyID = 2 },
                new AccountType_Currency { ID = 3, AccountTypeID = 2, CurrencyID = 3 }
                );
        }
    }
}
