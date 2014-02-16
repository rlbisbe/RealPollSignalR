using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public Answer Correct { get; set; }
        public string QuestionText { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}