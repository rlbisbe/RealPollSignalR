using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Data
{
    public class FakeQuestionRepository : IQuestionRepository
    {

        public Question GetFromId(int id)
        {
            var question = new Question();
            question.QuestionId = 1;
            question.Answers = new List<Answer>();
            question.Answers.Add(new Answer() { AnswerId = 1, AnswerText = "Foo" });
            question.Answers.Add(new Answer() { AnswerId = 2, AnswerText = "Bar" });
            question.Answers.Add(new Answer() { AnswerId = 4, AnswerText = "Baz" });
            question.Answers.Add(new Answer() { AnswerId = 7, AnswerText = "Bak", IsCorrect = true });

            return question;
        }


        public Question Add(Question q)
        {
            q.QuestionId = 5;
            return q;
        }


        public Question GenerateNewQuestion()
        {
            var q = new Question();
            q.Answers = new List<Answer>();
            return GetFromId(9);
        }
    }
}