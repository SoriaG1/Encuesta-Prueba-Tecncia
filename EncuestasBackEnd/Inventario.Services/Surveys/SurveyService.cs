using AutoMapper;
using Inventario.DataAccess;
using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Dtos.Users;
using Inventario.Entities.Surveys;
using Inventario.Entities.Users;
using Inventario.Services.Contrats;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Surveys
{
    public class SurveyService : ISurveyService
    {
        private readonly EncuestasDbContext _context;
        private readonly IMapper _mapper;
        public SurveyService(EncuestasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddSurveyAsync(NewSurveyDto surveyDto)
        {
            var survey = new Survey
            {
                Name = surveyDto.Name,
                Description = surveyDto.Description,
                RegistrationDate = surveyDto.RegistrationDate,
                StartDate = surveyDto.StartDate,
                EndDate = surveyDto.EndDate
            };
            _context.Surveys.Add(survey);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditSurveyAsync(int id, EditSurveyDto survey)
        {
            var currentSurvey = await _context.Surveys.FindAsync(id);
            if (currentSurvey != null)
            {
                _context.Entry(currentSurvey).CurrentValues.SetValues(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SurveyDto> GetSurveyAsync(int id)
        {
            Survey survey = await _context.Surveys.Where(x => x.Id == id).FirstOrDefaultAsync();
            SurveyDto surveyDto = _mapper.Map<SurveyDto>(survey);
            return surveyDto;
        }

        public async Task<IEnumerable<SurveyDto>> GetSurveysAsync()
        {
            List<Survey> surveys = await _context.Surveys.ToListAsync();
            List<SurveyDto> surveysDto = new List<SurveyDto>();
            foreach (var survey in surveys)
            {
                surveysDto.Add(_mapper.Map<SurveyDto>(survey));
            }

            return surveysDto;
        }
    }
}
