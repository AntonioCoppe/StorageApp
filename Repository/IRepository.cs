

namespace WireMockDemo.Entities{
     public interface IRepository<out T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T item);
        void Remove(T item);
        void save();
    }
}    
   