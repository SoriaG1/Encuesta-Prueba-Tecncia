using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Surveys.Questions
{
    public class Option
    {
        public int Id { get; set; }
        public string TextOption { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }

}
