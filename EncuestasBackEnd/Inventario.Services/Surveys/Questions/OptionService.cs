using AutoMapper;
using Inventario.DataAccess;
using Inventario.Entities.Dtos.Surveys.Questions;
using Inventario.Entities.Surveys;
using Inventario.Entities.Surveys.Questions;
using Inventario.Services.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Surveys.Questions
{
    public class OptionService : IOptionService
    {
        private readonly EncuestasDbContext _encuestasDbContext;
        private readonly IMapper _mapper;

        public OptionService(EncuestasDbContext encuestasDbContext, IMapper mapper) 
        {
            _encuestasDbContext = encuestasDbContext;
            _mapper = mapper;
        }
        public async Task<int> AddOptionAsync(NewOptionDto optionDto)
        {
            var question = await _encuestasDbContext.Questions.FindAsync(optionDto.QuestionId);
            if (question != null && question.TypeQuestion == Question.QuestionType.WithOptions)
            {
                var option = new Option
                {
                    TextOption = optionDto.TextOption,
                    QuestionId = optionDto.QuestionId
                };

                _encuestasDbContext.Options.Add(option);
                return await _encuestasDbContext.SaveChangesAsync();
            }
            else 
            {
                return 0;
            }
        }

        public async Task DeleteOptionAsync(int id)
        {
            var option = await _encuestasDbContext.Options.FindAsync(id);
            if (option != null) 
            {
                _encuestasDbContext.Options.Remove(option);
                await _encuestasDbContext.SaveChangesAsync();
            }
        }

        public async Task EditOptionAsync(int id, EditOptionDto questionDto)
        {
            var options = await _encuestasDbContext.Options.FindAsync(id);
            if (options != null) 
            {
                _encuestasDbContext.Entry(options).CurrentValues.SetValues(questionDto);
                await _encuestasDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OptionDto>> GetOptionsAsync(int questionId)
        {
            List<Option> options = await _encuestasDbContext.Options.Where(q => q.QuestionId == questionId).ToListAsync();
            List<OptionDto> optionsDto = new List<OptionDto>();
            foreach (var option in options) 
            {
                optionsDto.Add(_mapper.Map<OptionDto>(option));
            }
            return optionsDto;
        }
    }
}
