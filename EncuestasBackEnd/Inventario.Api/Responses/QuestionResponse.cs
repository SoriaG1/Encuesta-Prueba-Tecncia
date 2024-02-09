using Inventario.Entities.Dtos.Surveys.Questions;

namespace Encuestas.Api.Responses
{
    public class QuestionResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public QuestionDto Model { get; set; }
        public string RequestId { get; set; }
    }
}
