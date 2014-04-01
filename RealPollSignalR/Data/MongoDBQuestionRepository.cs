using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RealPollSignalR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Data
{
    public class MongoDBQuestionRepository : IQuestionRepository
    {
        private MongoCollection<Question> _collection;

        public MongoDBQuestionRepository()
        {
            var connectionString = ConfigurationManager.AppSettings["mongodb:connectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("realpoll");
            _collection = database.GetCollection<Question>("questions");

        }

        public Models.Question GetFromDisplayHash(int id)
        {
            var query = Query<Question>.EQ(e => e.DisplayHash, id);
            var entity = _collection.FindOne(query);

            return entity;
        }

        public Models.Question Add(Models.Question q)
        {
            byte[] hashBytes = q.QuestionUniqueId.ToByteArray();

            q.DisplayHash = BitConverter.ToUInt16(hashBytes, 0);
            q.AdminHash = BitConverter.ToUInt16(hashBytes, 8);
            _collection.Insert(q);

            return q;
        }

        public Models.Question GenerateNewQuestion()
        {
            return new Question() { QuestionUniqueId = Guid.NewGuid()};
        }

        public Models.Question GetFromAdminHash(int id)
        {
            var query = Query<Question>.EQ(e => e.DisplayHash, id);
            var entity = _collection.FindOne(query);

            return entity; 
        }


        public int GetQuestionCount()
        {
            return (int)_collection.Count();
        }
    }
}