using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class AccountSeed : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account { AccountNumber = 12345, UserID = 1, Alias = "Cuenta Ahorro Pesos", AccountTypeID = 1, CurrencyID = 1, Balance = 0, CBU = "1234-5-6789-1111111111111", UUID = null },
                new Account { AccountNumber = 67891, UserID = 1, Alias = "Cuenta Ahorro Dolares", AccountTypeID = 1, CurrencyID = 2, Balance = 0, CBU = "1234-5-6789-2222222222222", UUID = null },
                new Account { AccountNumber = 54321, UserID = 1, Alias = "Cuenta BTC", AccountTypeID = 2, CurrencyID = 3, Balance = 0, CBU = null, UUID = "A1B2C3D4-E5F6-G8H9-I110-J11K12L13M14" },
                new Account { AccountNumber = 78645, UserID = 2, Alias = "Mis pesitos", AccountTypeID = 1, CurrencyID = 1, Balance = 0, CBU = "4321-3-9876-3333333333333", UUID = null },
                new Account { AccountNumber = 78432, UserID = 2, Alias = "Mi bitcoin", AccountTypeID = 2, CurrencyID = 3, Balance = 0, CBU = null, UUID = "D1C2B3A4-F5E6-H8G9-110I-M11L12K13J14" }
                );
        }
    }
}
