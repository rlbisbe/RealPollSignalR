using RealPollSignalR.Data;
using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealPollSignalR.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionRepository repository;

        public QuestionController()
        {
            repository = new FakeQuestionRepository();
        }

        public ActionResult New()
        {
            var question = repository.GenerateNewQuestion();
            return View(question);
        }

        [HttpPost]
        public ActionResult New(Question q)
        {
            var added = repository.Add(q);
            return RedirectToAction("Result", new { id = added.QuestionId });
        }

        public ActionResult Result(int id)
        {
            var question = repository.GetFromId(id); 
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Vote(int id)
        {
            var question = repository.GetFromId(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
    }
}