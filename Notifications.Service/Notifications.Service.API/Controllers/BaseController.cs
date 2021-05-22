using Microsoft.AspNetCore.Mvc;
using Notifications.Service.Shared.Commands;

namespace Notifications.Service.API.Controllers
{
    public class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(GenericCommandResult result) => StatusCode(result.StatusCode, result);
    }
}
