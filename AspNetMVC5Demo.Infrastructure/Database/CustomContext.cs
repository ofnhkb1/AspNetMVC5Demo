using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;

using AspNetMVC5Demo.Domian.Model;
using AspNetMVC5Demo.Infrastructure.Map;

namespace AspNetMVC5Demo.Infrastructure.Database
{

    // EF6 开始提供拦截器功能，位于 System.Data.Entity.Infrastructure.Interception.DbCommandInterceptor 该对象，我们可以通过重写该对象中的方法，监控执行的 T-SQL 语句
    // MiniProfiler.EF
    // EF 迁移

    public class CustomDbContext : DbContext
    {
        public CustomDbContext()
            : base("name=default")
        {
            // 关闭实体跟踪
            base.Configuration.AutoDetectChangesEnabled = false;
            // 禁用延迟加载
            base.Configuration.LazyLoadingEnabled = false;
            // 关闭提交时验证数据
            base.Configuration.ValidateOnSaveEnabled = false;
            // 好像是创建代理的意思
            base.Configuration.ProxyCreationEnabled = false;
        }

        static CustomDbContext()
        {
            DbInterception.Add(new OurInterception());

            System.Data.Entity.Database.SetInitializer<CustomDbContext>(null);

            // 模型变化时，删除数据库重新生成数据库
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomContext>());

            // 每次都删除数据库重新生成数据库
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<CustomContext>());
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<AbortTask> AbortTask { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new AbortTaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Abort
    {
        public void Set()
        {
            using (CustomDbContext dbcontext = new CustomDbContext())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
    }
}