using Microsoft.AspNetCore.Mvc;

namespace Inventario.Api.Responses
{
    public class InternalServerError : ObjectResult
    {
        public InternalServerError(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public InternalServerError() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
