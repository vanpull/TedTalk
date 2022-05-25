using Microsoft.AspNetCore.Mvc;

namespace TedTalk.WebHost.HttpApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
        public ApiControllerBase()
        {
        }

        protected ActionResult<ApiResponse> Error()
        {
            var error = new ServerErrorResponse("Request failed", null)
            {
                Error = new ApiError(500, "An unknown error occured while processing your request")
            };
            return new ObjectResult(error) { StatusCode = 500 };
        }
    }
}
