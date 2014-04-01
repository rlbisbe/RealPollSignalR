using RealPollSignalR.Areas.Admin.Models;
using RealPollSignalR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealPollSignalR.Areas.Admin.Controllers
{
    public class StatsController : Controller
    {
        IQuestionRepository _repository;

        public StatsController(IQuestionRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/Stats
        public ActionResult Index()
        {
            StatisticsModel model = new StatisticsModel();
            model.TotalQuestions = _repository.GetQuestionCount();
            return View(model);
        }
    }
}
