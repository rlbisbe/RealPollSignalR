using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealPollSignalR.Models;

namespace RealPollSignalR.Data
{
    public interface IQuestionRepository
    {
        Question GetFromDisplayHash(int id);

        Question Add(Question q);

        Question GenerateNewQuestion();

        Question GetFromAdminHash(int id);

        int GetQuestionCount();
    }
}