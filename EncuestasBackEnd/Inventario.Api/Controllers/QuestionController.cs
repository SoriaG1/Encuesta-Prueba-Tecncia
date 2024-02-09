using Encuestas.Api.Responses;
using Inventario.Entities.Dtos.Surveys;
using Inventario.Entities.Dtos.Surveys.Questions;
using Inventario.Entities.Surveys;
using Inventario.Entities.Surveys.Questions;
using Inventario.Services.Contrats;
using Inventario.Services.Surveys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService) 
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<QuestionListResponse> Get(int surveyId)
        {
            return new QuestionListResponse
            {
                HasError = false,
                Message = "Questions returned",
                Model = (List<QuestionDto>) await _questionService.GetQuestionsAsync(surveyId),
                RequestId = System.Diagnostics.Activity.Current?.Id
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewQuestionDto value)
        {
            if (ModelState.IsValid)
            {
                await _questionService.AddQuestionAsync(value);
                return Ok(new
                {
                    hasError = false,
                    message = "Question added",
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
        public async Task<IActionResult> Put(int id, [FromBody] EditQuestionDto value)
        {
            if (ModelState.IsValid)
            {
                await _questionService.EditQuestionAsync(id, value);
                return Ok(new
                {
                    hasError = false,
                    message = "Survey Updated",
                    model = value,
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
                await _questionService.DeleteQuestionAsync(id);
                return Ok(new
                {
                    hasError = false,
                    message = "Question Deleted",
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
