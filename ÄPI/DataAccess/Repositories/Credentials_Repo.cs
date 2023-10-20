using ÄPI.Entities;

namespace ÄPI.DataAccess.Repositories
{
    public class Credentials_Repo : Main_Repo<Credentials>
    {
        public Credentials_Repo(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
