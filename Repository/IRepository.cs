

namespace WireMockDemo.Entities
{
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void save();
    }

    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
       
    }
}    
   