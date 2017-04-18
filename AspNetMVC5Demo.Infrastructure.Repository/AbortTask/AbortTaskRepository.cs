using AspNetMVC5Demo.Domian.Repository.AbortTask;
using AspNetMVC5Demo.Infrastructure.UnitOfWork;

namespace AspNetMVC5Demo.Infrastructure.Repository.AbortTask
{
    public class AbortTaskRepository : RepositoryBase<Domian.Model.AbortTask>, IAbortTaskRepository
    {
        public AbortTaskRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}