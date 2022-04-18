using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Controllers
{
    public class ResidenceController : Controller
    {
        private readonly ILogger<ResidenceController> _logger;

        public ResidenceController(ILogger<ResidenceController> logger)
        {
            _logger = logger;
        }

        public IActionResult BlockList()
        {
            return View();
        }

        public IActionResult FlatList()
        {
            return View();
        }
    }
}
