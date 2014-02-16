using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealPollSignalR.Models;

namespace RealPollSignalR.Data
{
    public interface IQuestionRepository
    {
        Question GetFromId(int id);

        Question Add(Question q);

        Question GenerateNewQuestion();
    }
}