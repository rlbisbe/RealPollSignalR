using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Data
{
    public class FakeQuestionRepository : IQuestionRepository
    {

        public Question GetFromDisplayHash(int id)
        {
            var question = new Question();
            question.Id = 1;
            question.QuestionText = "What does the fox says?";
            question.Answers = new List<Answer>();
            question.Answers.Add(new Answer() { Id = 1, AnswerText = "Foo" });
            question.Answers.Add(new Answer() { Id = 2, AnswerText = "Bar" });
            question.Answers.Add(new Answer() { Id = 4, AnswerText = "Baz" });
            question.Answers.Add(new Answer() { Id = 7, AnswerText = "Bak", IsCorrect = true });
            question.DisplayHash = 123;
            question.AdminHash = 123;

            return question;
        }

        public Question GetFromAdminHash(int id)
        {
            return GetFromDisplayHash(9);
        }

        public Question Add(Question q)
        {
            q.Id = 5;
            return q;
        }


        public Question GenerateNewQuestion()
        {
            var q = new Question();
            q.Answers = new List<Answer>();
            return GetFromDisplayHash(9);
        }

        public int GetQuestionCount()
        {
            return 100;
        }
    }
}