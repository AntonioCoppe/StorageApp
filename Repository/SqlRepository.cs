using Microsoft.EntityFrameworkCore;



namespace WireMockDemo.Entities
{
    public delegate void ItemAdded(Object item);
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly ItemAdded? _itemAddedCallback;
        private readonly DbContext _dbContext;
        
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item=>item.Id).ToList();
        }

        public SqlRepository(DbContext dbContext, ItemAdded? ItemAddedCallback = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
        public void save()
        {
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(object johnManagerCopy)
        {
            throw new NotImplementedException();
        }
    }
}