using Inventario.Entities.Dtos.Surveys.Questions;

namespace Encuestas.Api.Responses
{
    public class QuestionListResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public List<QuestionDto> Model { get; set; }
        public string RequestId { get; set; }
    }
}
