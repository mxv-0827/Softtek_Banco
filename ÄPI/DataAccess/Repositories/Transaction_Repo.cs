using ÄPI.Entities;

namespace ÄPI.DataAccess.Repositories
{
    public class Transaction_Repo : Main_Repo<Transaction>
    {
        public Transaction_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
