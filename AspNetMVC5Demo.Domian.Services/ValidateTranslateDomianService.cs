using System;

using AspNetMVC5Demo.Domian.Model;
using AspNetMVC5Demo.Domian.Model.Services;
using AspNetMVC5Demo.Domian.Repository.AbortTask;
using AspNetMVC5Demo.Domian.Repository.Account;

namespace AspNetMVC5Demo.Domian.Services
{
    public class ValidateTranslateDomianService : IValidateTranslateDomianService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAbortTaskRepository _abortTaskRepository;

        public ValidateTranslateDomianService(IAccountRepository accountRepository, IAbortTaskRepository abortTaskRepository)
        {
            this._accountRepository = accountRepository;
            this._abortTaskRepository = abortTaskRepository;
        }

        public AbortTask Validate(int from, int to, int task)
        {
            AbortTask @default = this._abortTaskRepository.Find(task);
            if (@default == null)
            {
                throw new Exception($"ID {task} 指定的任务不存在!");
            }
            Account fa = this._accountRepository.Find(from);
            if (fa == null)
            {
                throw new Exception($"ID {from} 该账号不存在!");
            }
            Account ta = this._accountRepository.Find(from);
            if (ta == null)
            {
                throw new Exception($"ID {to} 该账号不存在!");
            }

            return @default;
        }

        // 用于验证，实体?还是服务来做???
        public void Validate(AbortTask task, Account from, Account to)
        {

        }
    }
}