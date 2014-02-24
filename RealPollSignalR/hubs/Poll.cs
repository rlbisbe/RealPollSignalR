using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using RealPollSignalR.Models;
using RealPollSignalR.Data;

namespace RealPollSignalR
{
    public class Poll : Hub
    {
        IQuestionRepository _repository;

        public Poll(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public void Vote(string name, int questionId, int option)
        {
            Question q = _repository.GetFromDisplayHash(questionId);
            if (q == null)
            {
                return;
            }

            var valid = (from a in q.Answers where a.Id == option select a.IsCorrect).FirstOrDefault();

            Clients.All.castVote(name, questionId, option, valid);
        }
    }
}