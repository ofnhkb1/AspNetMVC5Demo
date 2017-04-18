using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetMVC5Demo.Domian.Repository
{
    public interface IQueryRepository<TEntity>
    {
        TEntity Find(int id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        IQueryable<TEntity> All();
    }

    public interface IQueryRepositoryAsync<out TEntity>
    {
    }
}