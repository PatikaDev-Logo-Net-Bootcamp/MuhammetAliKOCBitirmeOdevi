using Business.DTO;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,Manager")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        
        public UserController(ILogger<UserController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginDTO();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var userEntity = await _userManager.FindByEmailAsync(model.Email);
                if (userEntity != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(userEntity.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"{model.Email} Maail user logged in.");
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            return View(model);
        }

        public IActionResult Get()
        {
            var model = _userManager.Users.Select(x=>new UserDTO()
            {
                UserName = x.UserName,
                AccessFailedCount = x.AccessFailedCount,    
                ConcurrencyStamp = x.ConcurrencyStamp,  
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,  
                FirstName = x.FirstName,    
                LastName = x.LastName,  
                LockoutEnabled=x.LockoutEnabled,
                PhoneNumberConfirmed=x.PhoneNumberConfirmed,    
                LockoutEnd=x.LockoutEnd,
                NormalizedEmail=x.NormalizedEmail,    
                NormalizedUserName=x.NormalizedUserName,    
                PhoneNumber=x.PhoneNumber,
                PictureUrl=x.PictureUrl,
                TwoFactorEnabled=x.TwoFactorEnabled,    
                SecurityStamp=x.SecurityStamp,  
            }).ToList();
            return View(model);
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
