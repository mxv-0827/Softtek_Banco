using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class TransactionSeed : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(
                new Transaction { ID = 1, SourceAccount = 12345, DestinationAccount = 67891, Type = "Transfer", CurrencyID = 1, Amount = 1000 },
                new Transaction { ID = 2, SourceAccount = null, DestinationAccount = 12345, Type = "Deposit", CurrencyID = 2, Amount = 350 },
                new Transaction { ID = 3, SourceAccount = 78645, DestinationAccount = null, Type = "Withdrawal", CurrencyID = 1, Amount = 700 }
                );
        }
    }
}
