using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Dtos.Surveys.Questions;
using Inventario.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Contrats
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsAsync(int surveyId);
        Task<int> AddQuestionAsync(NewQuestionDto questionDto);
        Task EditQuestionAsync(int id, EditQuestionDto questionDto);
        Task DeleteQuestionAsync(int id);
    }
}
