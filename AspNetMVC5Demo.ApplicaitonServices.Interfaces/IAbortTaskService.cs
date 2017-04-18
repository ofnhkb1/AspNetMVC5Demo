using System.Collections.Generic;

using AspNetMVC5Demo.Dtos;

namespace AspNetMVC5Demo.ApplicaitonServices.Interfaces
{
    public interface IAbortTaskService : IApplicaitonService
    {
        IList<AbortTaskDto> Fetch();

        void Add(AbortTaskDto model);

        void Delete(int id);

        /// <summary>
        /// 分配任务
        /// </summary>
        void Translate(TranslateDto model);
    }
}