using ÄPI.DataAccess.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Main_Repo<T> : IRepository<T> where T: class
    {
        protected readonly ApplicationDBContext _dbContext;

        public Main_Repo(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<T>> GetAllEntities() => await _dbContext.Set<T>().ToListAsync(); //Returns all entities.
        public virtual async Task<T>? GetEntityById(int id) => await _dbContext.Set<T>().FindAsync(id); //Returns one entity based on the 'id' assigned value.

        public virtual async Task<bool> AddEntity(T entity)
        {
            var success = await _dbContext.AddAsync(entity);
            return success != null;
        }

        public virtual async Task<bool> UpdateEntity(T entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
