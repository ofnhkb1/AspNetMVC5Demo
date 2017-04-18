using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using AspNetMVC5Demo.Domian.Model;
using AspNetMVC5Demo.Domian.Repository;
using AspNetMVC5Demo.Infrastructure.UnitOfWork;

namespace AspNetMVC5Demo.Infrastructure.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public virtual void Add(TEntity entity)
        {
            this.UnitOfWork.CustomContext.Set<TEntity>().Attach(entity);
            this.UnitOfWork.CustomContext.Entry(entity).State = EntityState.Added;
        }

        public virtual void Delete(int id)
        {
            TEntity entity = new TEntity { Id = id, };
            this.Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this.UnitOfWork.CustomContext.Set<TEntity>().Attach(entity);
            this.UnitOfWork.CustomContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entity, params string[] columns)
        {
            var entry = this.UnitOfWork.CustomContext.Entry(entity);
            entry.State = EntityState.Unchanged; // ???
            if (columns != null && columns.Any())
            {
                foreach (string column in columns)
                {
                    entry.Property(column).IsModified = true;
                }
            }
        }

        public virtual void Update<TKey>(TEntity entity, params Expression<Func<TEntity, TKey>>[] columns)
        {
            var entry = this.UnitOfWork.CustomContext.Entry(entity);
            entry.State = EntityState.Unchanged; // ???
            if (columns != null && columns.Any())
            {
                foreach (var column in columns)
                {
                    entry.Property<TKey>(column).IsModified = true;
                }
            }
        }

        public virtual IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return this.UnitOfWork.CustomContext.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity Find(int id)
        {
            return this.UnitOfWork.CustomContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.UnitOfWork.CustomContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> All()
        {
            return this.UnitOfWork.CustomContext.Set<TEntity>();
        }
    }
}