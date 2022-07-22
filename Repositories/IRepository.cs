namespace Repositories
{
    public interface IRepository<TItem, TId>
    {
        ValueTask AddAsync(TItem item);

        ValueTask UpdateAsync(TItem item);

        ValueTask DeleteAsync(TId id);

        ValueTask<IEnumerable<TItem>> GetAllAsync();

        ValueTask<TItem> GetByIdAsync(TId id);
    }
}
