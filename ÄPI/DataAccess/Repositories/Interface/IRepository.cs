namespace ÄPI.DataAccess.Repositories.Interface
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllEntities();
        public Task<T>? GetEntityById(int id);
        public Task<bool> AddEntity(T entity);
        public Task<bool> UpdateEntity(T entity, int id);

        //Delete not included due to possible data conflicts among related tables => POSSIBLY ADDED IF TIME IS ENOUGH FOR IT.
    }
}
