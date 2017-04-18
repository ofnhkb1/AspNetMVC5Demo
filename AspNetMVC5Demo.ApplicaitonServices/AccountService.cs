using System;
using System.Collections.Generic;
using System.Linq;

using AspNetMVC5Demo.ApplicaitonServices.Interfaces;
using AspNetMVC5Demo.Domian.Model;
using AspNetMVC5Demo.Domian.Repository.Account;
using AspNetMVC5Demo.Dtos;
using AspNetMVC5Demo.Infrastructure.UnitOfWork;

namespace AspNetMVC5Demo.ApplicaitonServices
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            this._unitOfWork = unitOfWork;
            this._accountRepository = accountRepository;
        }

        public void Add(AccountDto model)
        {
            var account = new Account(model.Name);

            this._accountRepository.Add(account);
            this._unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            this._accountRepository.Delete(id);

            this._unitOfWork.Commit();
        }

        public IList<AccountDto> Fetch()
        {
            var accounts = this._accountRepository.All().Select(_ => new AccountDto()
            {
                Id = _.Id,
                Name = _.Name,
            }).ToList();

            return accounts;
            // 涉及到持久化的问题一定要提交当前工作单元
        }
    }
}