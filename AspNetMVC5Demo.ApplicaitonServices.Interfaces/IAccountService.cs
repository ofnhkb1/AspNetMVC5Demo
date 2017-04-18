
using System.Collections.Generic;

using AspNetMVC5Demo.Dtos;

namespace AspNetMVC5Demo.ApplicaitonServices.Interfaces
{
    public interface IAccountService : IApplicaitonService
    {
        IList<AccountDto> Fetch();

        void Add(AccountDto model);

        void Delete(int id);
    }
}