using Encuestas.Api.Responses;
using Inventario.Api.Responses;
using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Dtos.Users;
using Inventario.Entities.Surveys;
using Inventario.Services.Contrats;
using Inventario.Services.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<SurveyListResponse> Get()
        {
            return new SurveyListResponse
            {
                HasError = false,
                Message = "List of surveys returned",
                Model = (List<SurveyDto>)await _surveyService.GetSurveysAsync(),
                RequestId = System.Diagnostics.Activity.Current?.Id
            };
        }

        [HttpGet("{id}")]
        public async Task<SurveyResponse> Get(int id)
        {
            return new SurveyResponse
            {
                HasError = false,
                Message = "Survey returned",
                Model = await _surveyService.GetSurveyAsync(id),
                RequestId = System.Diagnostics.Activity.Current?.Id
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewSurveyDto value)
        {
            if (ModelState.IsValid) 
            {
                await _surveyService.AddSurveyAsync(value);
                return Ok(new
                {
                    hasError = false,
                    message = "Survey added",
                    model = (List<SurveyDto>)await _surveyService.GetSurveysAsync(),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditSurveyDto value)
        {
            if (ModelState.IsValid)
            {
                await _surveyService.EditSurveyAsync(id, value);
                return Ok(new
                {
                    hasError = false,
                    message = "Survey Updated",
                    model = (List<SurveyDto>)await _surveyService.GetSurveysAsync(),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                await _surveyService.DeleteSurveyAsync(id);
                return Ok(new
                {
                    hasError = false,
                    message = "Survey Deleted",
                    model = (List<SurveyDto>)await _surveyService.GetSurveysAsync(),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }
    }
}
