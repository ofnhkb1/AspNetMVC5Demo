using AspNetMVC5Demo.Domian.Repository.Account;
using AspNetMVC5Demo.Infrastructure.UnitOfWork;

namespace AspNetMVC5Demo.Infrastructure.Repository.Account
{

    public class AccountRepository : RepositoryBase<Domian.Model.Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}