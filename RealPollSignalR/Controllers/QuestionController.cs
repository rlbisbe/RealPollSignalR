using RealPollSignalR.Data;
using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace RealPollSignalR.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public ActionResult New()
        {
            var question = _repository.GenerateNewQuestion();
            return View(question);
        }

        [HttpPost]
        public ActionResult New(Question q)
        {
            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(BitConverter.GetBytes(q.Id));

            q.DisplayHash = BitConverter.ToInt16(hashBytes, 0);
            q.AdminHash = BitConverter.ToInt16(hashBytes, 8);

            var added = _repository.Add(q);
            return RedirectToAction("Result", new { id = added.Id });
        }

        public ActionResult Result(int id)
        {
            var question = _repository.GetFromDisplayHash(id); 
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Vote(int id)
        {
            var question = _repository.GetFromDisplayHash(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
    }
}