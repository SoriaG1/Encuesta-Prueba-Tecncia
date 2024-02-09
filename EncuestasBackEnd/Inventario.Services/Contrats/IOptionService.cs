using Inventario.Entities.Dtos.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Contrats
{
    public interface IOptionService
    {
        Task<IEnumerable<OptionDto>> GetOptionsAsync(int questionId);
        Task<int> AddOptionAsync(NewOptionDto questionDto);
        Task EditOptionAsync(int id, EditOptionDto questionDto);
        Task DeleteOptionAsync(int id);
    }
}
