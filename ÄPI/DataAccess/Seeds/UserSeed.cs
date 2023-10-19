using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace ÄPI.DataAccess.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { DNI = 44380182, Fullname = "Maximo Viand", BirthDate = DateTime.ParseExact("27/08/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), Genre = "Masculino" },
                new User { DNI = 40898968, Fullname = "Gerardo Viand", BirthDate = DateTime.ParseExact("16/11/1966", "dd/MM/yyyy", CultureInfo.InvariantCulture), Genre = "Masculino" }
                );
        }
    }
}
