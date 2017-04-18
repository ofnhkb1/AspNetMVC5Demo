using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

using NLog;

namespace AspNetMVC5Demo.Infrastructure.Database
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class OurInterception : System.Data.Entity.Infrastructure.Interception.DbCommandInterceptor
    {
        private readonly Logger _logger = LogManager.GetLogger("sql");

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            _logger.Info($"Reader: {command.CommandText}");

            base.ReaderExecuting(command, interceptionContext);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            _logger.Info($"NonQuery: {command.CommandText}");

            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            _logger.Info($"Scalar: {command.CommandText}");

            base.ScalarExecuting(command, interceptionContext);
        }
    }
}