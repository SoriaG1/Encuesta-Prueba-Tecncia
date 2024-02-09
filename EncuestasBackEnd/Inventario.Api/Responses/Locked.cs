using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Api.Responses
{
    public class Locked : ObjectResult
    {
        public Locked(object value) : base(value)
        {
            StatusCode = StatusCodes.Status423Locked;
        }

        public Locked() : this(null)
        {
            StatusCode = StatusCodes.Status423Locked;
        }
    }
}
