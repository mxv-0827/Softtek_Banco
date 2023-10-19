using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class AccountTypeSeed : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasData(
                new AccountType { ID = 1, Description = "Fiduciary" },
                new AccountType { ID = 2, Description = "Cryptocurrency" }
                );
        }
    }
}
