namespace Repositories
{
    public interface IRepository<TItem, TId>
    {
        Task AddAsync(TItem item);

        Task UpdateAsync(TItem item);

        Task DeleteAsync(TId id);

        Task<IEnumerable<TItem>> GetAllAsync();

        Task<TItem> GetByIdAsync(TId id);
    }
}
