using Inventario.Entities.Dtos.Surveys.Questions;

namespace Encuestas.Api.Responses
{
    public class OptionResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public OptionDto Model { get; set; }
        public string RequestId { get; set; }
    }
}
