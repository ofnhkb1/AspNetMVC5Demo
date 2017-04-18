using System;

using AspNetMVC5Demo.Infrastructure.Database;

namespace AspNetMVC5Demo.Infrastructure.UnitOfWork
{
    public interface IAbortContext : IDisposable
    {

    }

    public interface IEfContext : IAbortContext
    {
        CustomDbContext CustomContext { get; }
    }

    // 定义一个对象，使用该对象统一管理事务单元
    public interface IUnitOfWork : IEfContext
    {
        string Key { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}