using Inventario.Entities.Dtos.Surveys;

namespace Encuestas.Api.Responses
{
    public class SurveyResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public SurveyDto Model { get; set; }
        public string RequestId { get; set; }
    }
}
