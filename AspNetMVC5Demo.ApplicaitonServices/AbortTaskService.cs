using System;
using System.Collections.Generic;
using System.Linq;

using AspNetMVC5Demo.ApplicaitonServices.Interfaces;
using AspNetMVC5Demo.Domian.Model;
using AspNetMVC5Demo.Domian.Repository.AbortTask;
using AspNetMVC5Demo.Domian.Repository.Account;
using AspNetMVC5Demo.Dtos;
using AspNetMVC5Demo.Infrastructure.UnitOfWork;

namespace AspNetMVC5Demo.ApplicaitonServices
{
    public class AbortTaskService : IAbortTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAbortTaskRepository _abortTaskRepository;
        private readonly IAccountRepository _accountRepository;
        //private readonly IValidateTranslateDomianService _validateTranslateDomianService;

        public AbortTaskService(IUnitOfWork unitOfWork, IAbortTaskRepository abortTaskRepository, IAccountRepository accountRepository)
        {
            this._unitOfWork = unitOfWork;
            this._accountRepository = accountRepository;
            this._abortTaskRepository = abortTaskRepository;
        }

        public void Add(AbortTaskDto model)
        {
            var task = new AbortTask(model.Name, model.Content);

            this._abortTaskRepository.Add(task);
            this._unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            this._abortTaskRepository.Delete(id);
            this._unitOfWork.Commit();
        }

        public IList<AbortTaskDto> Fetch()
        {
            var tasks = this._abortTaskRepository.All()
                .Select(_ => new AbortTaskDto()
                {
                    Id = _.Id,
                    Name = _.Name,
                    Content = _.Content,
                    From = _.From,
                    To = _.To,
                })
                .ToList();

            return tasks;
        }

        public void Translate(TranslateDto model)
        {
            //AbortTask task = this._validateTranslateDomianService.Validate(model.FromId, model.ToId, model.TaskId);
            //task.Translate(model.FromId, model.ToId);
            AbortTask task = this._abortTaskRepository.Find(model.TaskId);
            if (task == null)
            {
                throw new Exception("指定的任务不存在!");
            }
            Account from = this._accountRepository.Find(model.FromId);
            Account to = this._accountRepository.Find(model.ToId);
            task.Translate(from, to);
            // 这个实体中一定要有主键
            this._abortTaskRepository.Update(task, t => t.From, t => t.To);

            this._unitOfWork.Commit();
        }
    }
}