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
            var question = repository.GenerateNewQuestion();
            return View(question);
        }

        [HttpPost]
        public ActionResult Index(Question q)
        {
            var added = repository.Add(q);
            return RedirectToAction("Result", new[] { added.QuestionId });
        }

        public ActionResult Result(int id)
        {
            var question = repository.GetFromId(id);
            return View(question);
        }

        public ActionResult Vote(int id)
        {
            var question = repository.GetFromId(id);
            return View(question);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}