using ÄPI.DataAccess;
using ÄPI.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata.Ecma335;

namespace ÄPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public User_Repo UserRepo { get; private set; }
        public Credentials_Repo CredentialsRepo { get; private set; }
        public AccountType_Repo AccountTypeRepo { get; private set; }
        public Currency_Repo CurrencyRepo { get; private set; }
        public AccountTypeCurrency_Repo AccountTypeCurrencyRepo { get; private set; }
        public Account_Repo AccountRepo { get; private set; }
        public Transaction_Repo TransactionRepo { get; private set; }
        public CurrencyConverted_Repo CurrencyConverted_Repo { get; private set; }


        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;

            UserRepo = new User_Repo(_dbContext);
            CredentialsRepo = new Credentials_Repo(_dbContext);
            AccountTypeRepo = new AccountType_Repo(_dbContext);
            CurrencyRepo = new Currency_Repo(_dbContext);
            AccountTypeCurrencyRepo = new AccountTypeCurrency_Repo(_dbContext);
            AccountRepo = new Account_Repo(_dbContext);
            TransactionRepo = new Transaction_Repo(_dbContext);
            CurrencyConverted_Repo = new CurrencyConverted_Repo(_dbContext);
        }


        public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction(); //Initializes the transaction.
        public Task<int> Save() => _dbContext.SaveChangesAsync(); //Applies changes to database.
        public void Dispose() => _dbContext.Dispose(); //Release useless resources.
    }
}
