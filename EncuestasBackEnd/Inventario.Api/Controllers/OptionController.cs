using Encuestas.Api.Responses;
using Inventario.Entities.Dtos.Surveys.Questions;
using Inventario.Services.Contrats;
using Inventario.Services.Surveys.Questions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class OptionController : Controller
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<OptionListResponse> Get(int questionId)
        {
            return new OptionListResponse
            {
                HasError = false,
                Message = "Options returned",
                Model = (List<OptionDto>)await _optionService.GetOptionsAsync(questionId),
                RequestId = System.Diagnostics.Activity.Current?.Id
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewOptionDto value)
        {
            if (ModelState.IsValid)
            {
                await _optionService.AddOptionAsync(value);
                return Ok(new
                {
                    hasError = false,
                    message = "Option added",
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
        public async Task<IActionResult> Put(int id, [FromBody] EditOptionDto value)
        {
            if (ModelState.IsValid)
            {
                await _optionService.EditOptionAsync(id, value);
                return Ok(new
                {
                    hasError = false,
                    message = "Option updated",
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
                await _optionService.DeleteOptionAsync(id);
                return Ok(new
                {
                    hasError = false,
                    message = "Option deleted",
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
