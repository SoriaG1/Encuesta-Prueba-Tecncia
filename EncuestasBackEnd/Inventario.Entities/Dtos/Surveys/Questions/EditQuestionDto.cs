using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dtos.Surveys.Questions
{
    public class EditQuestionDto
    {
        public string TextQuestion { get; set; }
        public bool IsRequired { get; set; }
    }
}
