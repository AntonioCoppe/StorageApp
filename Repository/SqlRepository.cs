using Microsoft.EntityFrameworkCore;


namespace WireMockDemo.Entities
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public SqlRepository(DbContext dbContext)
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
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
        public void save()
        {
            _dbContext.SaveChanges();
        }


    }
}