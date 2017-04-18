using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AspNetMVC5Demo.ApplicaitonServices.Interfaces;
using AspNetMVC5Demo.Dtos;
using AspNetMVC5Demo.LogAbstractions;

using NLog;

namespace AspNetMVC5Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        // 做一个简单的流程，就是分配一个任务给某个人
        private readonly IAccountService _accountService;
        private readonly IAbortTaskService _abortTaskService;
        private readonly ILogger _logger;

        public HomeController(IAccountService accountService,
            IAbortTaskService abortTaskService, ICustomLogFactory logfactory)
        {
            this._accountService = accountService;
            this._abortTaskService = abortTaskService;
            this._logger = logfactory.Create("httpController");
        }

        // GET: Home
        public ActionResult Index()
        {
            this._logger.Info("HomeController/Index");

            return View();
        }

        public ActionResult RenderAccounts()
        {
            var accounts = this._accountService.Fetch();
            ViewBag.accounts = accounts;

            return View();
        }

        public ActionResult AddAccount(AccountDto model)
        {
            this._logger.Info("HomeController/AddAccount");
            this._accountService.Add(model);

            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult RenderTasks()
        {
            var tasks = this._abortTaskService.Fetch();
            ViewBag.tasks = tasks;

            return View();
        }

        public ActionResult AddTask(AbortTaskDto model)
        {
            this._logger.Info("HomeController/AddTask");
            this._abortTaskService.Add(model);

            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult Translate(TranslateDto model)
        {
            this._logger.Info("HomeController/Translate");
            this._abortTaskService.Translate(model);

            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult DeleteAccount(int id)
        {
            this._logger.Info("HomeController/DeleteAccount");
            this._accountService.Delete(id);

            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult DeleteTask(int id)
        {
            this._logger.Info("HomeController/DeleteTask");
            this._abortTaskService.Delete(id);

            return RedirectToAction("Index", "Home", new { });
        }
    }
}