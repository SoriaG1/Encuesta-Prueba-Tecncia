using Inventario.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Inventario.Entities.Surveys.Questions.Question;

namespace Inventario.Entities.Dtos.Surveys.Questions
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string TextQuestion { get; set; }
        public bool IsRequired { get; set; }
        public int SurveyID { get; set; }
    }
}
