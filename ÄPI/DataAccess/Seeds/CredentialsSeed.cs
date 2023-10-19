using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class CredentialsSeed : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.HasData(
                new Credentials { DNI = 44380182, Email = "maxiviand@gmail.com", Password = "1234" },
                new Credentials { DNI = 40898968, Email = "gerardviand@gmail.com", Password = "4321" }
                );
        }
    }
}
