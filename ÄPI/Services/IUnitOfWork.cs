using ÄPI.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ÄPI.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public User_Repo UserRepo { get; }
        public Credentials_Repo CredentialsRepo { get; }
        public AccountType_Repo AccountTypeRepo { get; }
        public Currency_Repo CurrencyRepo { get; }
        public AccountTypeCurrency_Repo AccountTypeCurrencyRepo { get; }
        public Account_Repo AccountRepo { get; }
        public Transaction_Repo TransactionRepo { get; }
        public CurrencyConverted_Repo CurrencyConverted_Repo { get; }


        public IDbContextTransaction BeginTransaction();
        public Task<int> Save();
    }
}
