using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Surveys.Questions
{
    public class Question
    {
        public int Id { get; set; }
        public string TextQuestion { get; set; }
        public QuestionType TypeQuestion { get; set; }
        public bool IsRequired { get; set; }
        public int SurveyID { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Option> Options { get; set; }

        public enum QuestionType
        {
            Open,
            WithOptions
        }
    }
}
