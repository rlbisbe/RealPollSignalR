using RealPollSignalR.Models;
using System;
using System.Linq;

namespace RealPollSignalR.Data
{
    public class DBQuestionRepository : IQuestionRepository
    {
        private QuestionContext _db;
        public DBQuestionRepository()
        {
            _db = new QuestionContext();
        }

        public Question GetFromDisplayHash(int id)
        {
            var question = from q in _db.Questions
                           where q.DisplayHash == id
                           select q;

            return question.FirstOrDefault();
        }

        public Question GetFromAdminHash(int id)
        {
            var question = from q in _db.Questions
                           where q.AdminHash == id
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

            byte[] hashBytes = q.QuestionUniqueId.ToByteArray();

            question.DisplayHash = BitConverter.ToUInt16(hashBytes, 0);
            question.AdminHash = BitConverter.ToUInt16(hashBytes, 8);

            _db.SaveChanges();
            return question;
        }

        public Question GenerateNewQuestion()
        {
            return new Question() { QuestionUniqueId = Guid.NewGuid()};
        }


        public int GetQuestionCount()
        {
            return _db.Questions.Count();
        }
    }
}