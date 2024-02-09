using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dtos.Surveys.Questions
{
    public class NewOptionDto
    {
        public int Id { get; set; }
        public string TextOption { get; set; }
        public int QuestionId { get; set; }
    }
}
