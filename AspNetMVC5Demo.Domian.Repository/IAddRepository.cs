namespace AspNetMVC5Demo.Domian.Repository
{
    public interface IAddRepository<in TEntity>
    {
        void Add(TEntity entity);
    }

    public interface IAddRepositoryAsync<in TEntity>
    {
        void AddAsync(TEntity entity);
    }
}