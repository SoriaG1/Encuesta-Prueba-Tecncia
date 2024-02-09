using Inventario.Entities.Dtos.Surveys.Questions;

namespace Encuestas.Api.Responses
{
    public class OptionListResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public List<OptionDto> Model { get; set; }
        public string RequestId { get; set; }
    }
}
