using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Api.Responses
{
    public class Unauthorized : ObjectResult
    {
        public Unauthorized(object value) : base(value)
        {
            //StatusCode = StatusCodes.Status401Unauthorized;
        }

        public Unauthorized() : this(null)
        {
            //StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
