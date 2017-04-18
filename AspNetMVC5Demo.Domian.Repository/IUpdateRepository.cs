using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AspNetMVC5Demo.Domian.Repository
{
    public interface IUpdateRepository<TEntity>
    {
        void Update(TEntity entity, params string[] columns);

        void Update<TKey>(TEntity entity, params Expression<Func<TEntity, TKey>>[] columns);
    }

    public interface IUpdateRepositoryAsync<in TEntity>
    {
        void UpdateAsync(TEntity entity);
    }
}