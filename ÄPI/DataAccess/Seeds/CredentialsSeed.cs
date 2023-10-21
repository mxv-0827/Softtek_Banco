using ÄPI.Entities;
using ÄPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ÄPI.DataAccess.Seeds
{
    public class CredentialsSeed : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.HasData(
                new Credentials { ID = 1, Email = "maxiviand@gmail.com", Password = PasswordEncrypter_Helper.EncryptPassword("1234", "maxiviand@gmail.com") },
                new Credentials { ID = 2, Email = "gerardviand@gmail.com", Password = PasswordEncrypter_Helper.EncryptPassword("4321", "gerardviand@gmail.com") }
                );
        }
    }
}
