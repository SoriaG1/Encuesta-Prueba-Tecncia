using Inventario.Entities.Dtos.Surveys;

namespace Encuestas.Api.Responses
{
    public class SurveyListResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public List<SurveyDto> Model { get; set; }
        public string RequestId { get; set; }
    }
}
