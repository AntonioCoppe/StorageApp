using Microsoft.EntityFrameworkCore;
using WireMockDemo.StorageApp.Data;

namespace WireMockDemo.Entities
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
  {
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
        private StorageAppDbContext storageAppDbContext;

        public SqlRepository(DbContext dbContext, Action<object> employeeAdded)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<T>();
    }

        public SqlRepository(StorageAppDbContext storageAppDbContext)
        {
            this.storageAppDbContext = storageAppDbContext;
        }

        public event EventHandler<T>? ItemAdded;

    public IEnumerable<T> GetAll()
    {
      return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T GetById(int id)
    {
      return _dbSet.Find(id);
    }

    public void Add(T item)
    {
      _dbSet.Add(item);
      ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
      _dbSet.Remove(item);
    }

    public void Save()
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

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}
