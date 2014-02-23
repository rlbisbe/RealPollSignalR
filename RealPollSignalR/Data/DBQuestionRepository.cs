using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Data
{
    public class DBQuestionRepository : IQuestionRepository
    {
        private QuestionContext _db;
        public DBQuestionRepository()
        {
            _db = new QuestionContext();
        }

        public Question GetFromId(int id)
        {
            var question = from q in _db.Questions
                           where q.Id == id
                           select q;

            return question.FirstOrDefault();
        }

        public Question Add(Question q)
        {
                var question = _db.Questions.Add(q);
                foreach (var answer in question.Answers)
                {
                    answer.QuestionId = question.Id;
                    _db.Answers.Add(answer);
                }
                _db.SaveChanges();
                return question;
        }

        public Question GenerateNewQuestion()
        {
            return new Question();
        }
    }
}