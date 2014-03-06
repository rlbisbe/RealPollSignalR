using RazorEngine.Templating;
using RealPollSignalR.Data;
using RealPollSignalR.Models;
using RealPollSignalR.Services;
using RealPollSignalR.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace RealPollSignalR.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionRepository _repository;
        IMailService _mailService;

        public QuestionController(IQuestionRepository repository, IMailService service)
        {
            _repository = repository;
            _mailService = service;
        }

        public ActionResult New()
        {
            var question = _repository.GenerateNewQuestion();
            return View(question);
        }

        [HttpPost]
        public ActionResult New(Question q)
        {
            var added = _repository.Add(q);
            return RedirectToAction("Created", "Question", new { id = added.DisplayHash });
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

        public ActionResult Created(int id)
        {
            var question = _repository.GetFromDisplayHash(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        [HttpPost]
        public ActionResult Email(EmailViewModel model)
        {
            var question = _repository.GetFromDisplayHash(model.QuestionId);
            var body = string.Empty;
            body = _mailService.GenerateEmailBody(new Question(question));

            if (_mailService.SendMail(model.Email, body, question.DisplayHash))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
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