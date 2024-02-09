using AutoMapper;
using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Dtos.Surveys.Questions;
using Inventario.Entities.Dtos.Users;
using Inventario.Entities.Surveys;
using Inventario.Entities.Surveys.Questions;
using Inventario.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Survey, SurveyDto>();
            CreateMap<Survey, NewSurveyDto>();
            CreateMap<Survey, EditSurveyDto>();
            CreateMap<EditSurveyDto, Survey>();
            CreateMap<NewSurveyDto, Survey>();
            CreateMap<SurveyDto, Survey>();

            CreateMap<User, UserDto>();
            CreateMap<User, NewUserDto>();
            CreateMap<User, EditUserDto>();
            CreateMap<UserDto, User>();
            CreateMap<NewUserDto, User>();
            CreateMap<EditUserDto, User>();

            CreateMap<Question, QuestionDto>();
            CreateMap<Question, NewQuestionDto>();
            CreateMap<Question, EditQuestionDto>();
            CreateMap<EditQuestionDto, Question>();
            CreateMap<NewQuestionDto, Question>();
            CreateMap<QuestionDto, Question>();

            CreateMap<Option, OptionDto>();
            CreateMap<Option, NewOptionDto>();
            CreateMap<Option, EditOptionDto>();
            CreateMap<EditOptionDto, Option>();
            CreateMap<NewOptionDto, Option>();
            CreateMap<OptionDto, Option>();
        }
    }
}
