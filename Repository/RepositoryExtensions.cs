namespace WireMockDemo.Entities
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, IEnumerable<T> items) where T : IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.save();
        }
    }
}
