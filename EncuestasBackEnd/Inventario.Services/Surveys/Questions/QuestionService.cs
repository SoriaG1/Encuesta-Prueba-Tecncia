using AutoMapper;
using Inventario.DataAccess;
using Inventario.Entities.Dtos.Surveys.Questions;
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
    public class QuestionService : IQuestionService
    {
        private readonly EncuestasDbContext _context;
        private readonly IMapper _mapper;

        public QuestionService(EncuestasDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddQuestionAsync(NewQuestionDto questionDto)
        {
            var question = new Question
            {
                Id = questionDto.Id,
                TextQuestion = questionDto.TextQuestion,
                TypeQuestion = questionDto.Type,
                IsRequired = questionDto.IsRequired,
                SurveyID = questionDto.SurveyID,
            };
            _context.Questions.Add(question);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditQuestionAsync(int id, EditQuestionDto questionDto)
        {
            var currentQuestion = await _context.Questions.FindAsync(id);
            if (currentQuestion != null)
            {
                _context.Entry(currentQuestion).CurrentValues.SetValues(questionDto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync(int surveyId)
        {
            List<Question> questions = await _context.Questions.Where(q => q.SurveyID == surveyId).ToListAsync();
            List<QuestionDto> questionsDto = new List<QuestionDto>();
            foreach (var question in questions)
            {
                questionsDto.Add(_mapper.Map<QuestionDto>(question));
            }
            return questionsDto;
        }
    }
}
