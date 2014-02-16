using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Data
{
    public class DBQuestionRepository : IQuestionRepository
    {
        public Question GetFromId(int id)
        {
            using (var db = new QuestionContext())
            {
                var question = (from q in db.Questions
                                where q.QuestionId == id
                                select q).FirstOrDefault();

                return question;
            }
        }

        public Question Add(Question q)
        {
            using (var db = new QuestionContext())
            {
                var question = db.Questions.Add(q);

                return question;
            }
        }


        public Question GenerateNewQuestion()
        {
            throw new NotImplementedException();
        }
    }
}