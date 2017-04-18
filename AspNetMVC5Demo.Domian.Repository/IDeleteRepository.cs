namespace AspNetMVC5Demo.Domian.Repository
{
    public interface IDeleteRepository<in TEntity>
    {
        void Delete(int id);

        void Delete(TEntity entity);
    }

    public interface IDeleteRepositoryAsync<in TEntity>
    {
        void DeleteAsync(int id);

        void DeleteAsync(TEntity entity);
    }
}