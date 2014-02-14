using RealPollSignalR.Data;
using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealPollSignalR.Controllers
{
    public class HomeController : Controller
    {
        IQuestionRepository repository;

        public HomeController()
        {
            repository = new FakeQuestionRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vote(int id)
        {
            var question = repository.GetFromId(id);
            return View(question);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}