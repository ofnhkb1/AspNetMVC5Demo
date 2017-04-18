using System;

using AspNetMVC5Demo.Infrastructure.Database;

namespace AspNetMVC5Demo.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            this.Key = Guid.NewGuid().ToString("N");
            this.CustomContext = new CustomDbContext();
        }

        public string Key { get; }

        public CustomDbContext CustomContext { get; }

        public void BeginTransaction()
        {
        }

        // 是否需要考虑并发情况
        public void Commit()
        {
            this.CustomContext?.SaveChanges();
        }

        public void Dispose()
        {
            this.CustomContext?.Dispose();
        }

        public void Rollback()
        {
            // ef 不需要主动回滚事务，当提交失败的时候会自动回滚当前 DbContext 
        }
    }
}