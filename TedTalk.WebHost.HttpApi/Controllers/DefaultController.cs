using Microsoft.AspNetCore.Mvc;

namespace TedTalk.WebHost.HttpApi.Controllers
{
    public class DefaultController : Controller
    {
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToSwaggerUi()
        {
            return Redirect("/docs/");
        }
    }
}
