namespace ÄPI.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> Save();
    }
}
