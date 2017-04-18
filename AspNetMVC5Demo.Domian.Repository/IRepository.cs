using AspNetMVC5Demo.Domian.Model;

namespace AspNetMVC5Demo.Domian.Repository
{
    public interface IRepository<TEntity> :
        IAddRepository<TEntity>,
        IDeleteRepository<TEntity>,
        IUpdateRepository<TEntity>,
        IQueryRepository<TEntity>
        where TEntity : IEntity
    {

    }

    // 异步版本
    public interface IRepositoryAsync<TEntity> :
        IAddRepositoryAsync<TEntity>,
        IDeleteRepositoryAsync<TEntity>,
        IUpdateRepositoryAsync<TEntity>,
        IQueryRepositoryAsync<TEntity>
        where TEntity : IEntity
    {

    }
}