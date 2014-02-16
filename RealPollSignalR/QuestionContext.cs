using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RealPollSignalR.Models;

namespace RealPollSignalR
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public System.Data.Entity.DbSet<RealPollSignalR.Models.Answer> Answers { get; set; }
    }
}