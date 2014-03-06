using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealPollSignalR.Models
{
    public class Question
    {
        public Question()
        {

        }

        public Question(Question question)
        {
            Id = question.Id;
            QuestionText = question.QuestionText;
            AdminHash = question.AdminHash;
            DisplayHash = question.DisplayHash;
            QuestionUniqueId = question.QuestionUniqueId;

            if (question.Answers != null && question.Answers.Count != 0)
            {
                Answers = new List<Answer>();
                foreach (var item in question.Answers)
                {
                    Answers.Add(new Answer()
                    {
                        AnswerText = item.AnswerText,
                        Id = item.Id,
                        IsCorrect = item.IsCorrect,
                        QuestionId = item.QuestionId
                    });
                }
            }
        }

        public int Id { get; set; }
        [Display(Name = "Question text:")]
        public string QuestionText { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public int AdminHash { get; set; }
        public int DisplayHash { get; set; }
        public Guid QuestionUniqueId { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Display(Name = "Answer text")]
        public string AnswerText { get; set; }
        [Display(Name = "Is Correct?")]
        public bool IsCorrect { get; set; }
    }
}