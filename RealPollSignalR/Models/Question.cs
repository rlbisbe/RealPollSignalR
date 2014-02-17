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
        [Display(Name = "Question text:")]
        public string QuestionText { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        [Display(Name="Answer text")]
        public string AnswerText { get; set; }
        [Display(Name = "Is Correct?")]
        public bool IsCorrect { get; set; }
    }
}