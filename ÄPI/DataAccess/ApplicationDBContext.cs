using ÄPI.DataAccess.Seeds;
using ÄPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType_Currency> AccountType_Currencies { get; set; }
        public DbSet<CurrencyConvertion> CurrenciesConvertions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(e => e.DNI).IsUnique(); //Add a unique index for the 'DNI' prop in 'User'.
            builder.Entity<Credentials>().HasIndex(e => e.Email).IsUnique(); //Add a unique index for the 'Email' prop in 'Credentials'.

            builder.Entity<Account>().HasIndex(e => e.CBU).IsUnique(); //Add a unique index for the 'CBU' prop in 'Account'.
            builder.Entity<Account>().HasIndex(e => e.UUID).IsUnique(); //Add a unique index for the 'UUID' prop in 'Account'.

            builder.ApplyConfiguration(new UserSeed());
            builder.ApplyConfiguration(new CredentialsSeed());
            builder.ApplyConfiguration(new AccountTypeSeed());
            builder.ApplyConfiguration(new CurrencySeed());
            builder.ApplyConfiguration(new AccountType_CurrencySeed());
            builder.ApplyConfiguration(new AccountSeed());
            builder.ApplyConfiguration(new CurrencyConvertionSeed());
        }
    }
}
