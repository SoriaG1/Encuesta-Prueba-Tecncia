using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Surveys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Contrats
{
    public interface ISurveyService
    {
        Task<IEnumerable<SurveyDto>> GetSurveysAsync();
        Task<SurveyDto> GetSurveyAsync(int id);
        Task<int> AddSurveyAsync(NewSurveyDto survey);
        Task EditSurveyAsync(int id, EditSurveyDto survey);
        Task DeleteSurveyAsync(int id);
    }
}
