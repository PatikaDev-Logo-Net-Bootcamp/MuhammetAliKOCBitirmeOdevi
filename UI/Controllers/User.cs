using Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class User : Controller
    {
       
        public IActionResult Login()
        {
            var model = new LoginDTO();
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(LoginDTO model)
        {
            return View();
        }

        public IActionResult Get()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

    }
}
