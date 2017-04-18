using System;

using NLog;

namespace AspNetMVC5Demo.LogAbstractions
{
    public interface ICustomLogFactory
    {
        NLog.ILogger Create<T>();

        NLog.ILogger Create(Type type);

        NLog.ILogger Create(string name);
    }

    public class CustomLogFactory : ICustomLogFactory
    {
        public ILogger Create<T>()
            => Create(typeof(T));

        public ILogger Create(Type type)
            => Create(type.Name);

        public ILogger Create(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}