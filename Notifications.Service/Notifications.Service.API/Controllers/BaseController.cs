using Microsoft.AspNetCore.Mvc;
using Notifications.Service.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Service.API.Controllers
{
    public class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(GenericCommandResult result) => StatusCode(result.StatusCode, result);
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(bool result) => StatusCode(1);
    }
}
