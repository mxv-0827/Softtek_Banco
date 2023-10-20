using ÄPI.DataAccess.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ÄPI.DataAccess.Repositories
{
    public class Main_Repo<T> : IRepository<T> where T: class
    {
        private readonly ApplicationDBContext _dbContext;

        public Main_Repo(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<T>> GetAllEntities() => await _dbContext.Set<T>().ToListAsync(); //Returns all entities.
        public virtual async Task<T>? GetEntityById(int id) => await _dbContext.Set<T>().FindAsync(id); //Returns one entity based on the 'id' assigned value.

        public virtual async Task<bool> AddEntity(T entity)
        {
            bool success = true;

            try
            {
                var error = await _dbContext.Set<T>().AddAsync(entity);
                _ = error != null ? success : !success;
            }

            catch (DbUpdateException ex) 
            {
                if(ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601) //'2601' is duplicate PK error code.
                {
                    throw new Exception("DNI already exists in database. Make sure you did not any mistake and try again.");
                }
                else
                {
                    throw new Exception(ex.InnerException?.Message); //Possible data validation errors.
                }
            }
            catch (Exception)
            {
                throw new Exception("Internal server error.");
            }

            return success;
        }

        public virtual async Task<bool> UpdateEntity(T entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
