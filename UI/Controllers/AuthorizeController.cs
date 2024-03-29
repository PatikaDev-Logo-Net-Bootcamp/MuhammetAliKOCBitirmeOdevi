﻿using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize]
    public class AuthorizeController : Controller
    {
        private readonly ILogger<AuthorizeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;


        public AuthorizeController(ILogger<AuthorizeController> logger, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Kullanıcı Adı yada Şifrenizi Kontrol Ediniz.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı Adı yada Şifrenizi Kontrol Ediniz.");
                }

            }
            return View(model);
        }

        public IActionResult ResetPasword()
        {
            var model = new ResetPasswordDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasword(ResetPasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.GetUserAsync(User).Result;

                var passwordValidator = new PasswordValidator<User>();
                var sifreKontrol = await passwordValidator.ValidateAsync(_userManager, currentUser, model.Password);

                if (model.Password != model.RePassword)
                {
                    model.IsSuccess = false;
                    model.Message = "İşlem başarısız. Girilen Şifreler Aynı Değil!";
                }else if (!sifreKontrol.Succeeded)//Şifre uygunluğu kontrol ediliyor. 
                {
                    model.IsSuccess = false;
                    model.Message = "Belirlediğiniz şifre geçerli bir şifre değil. Şifreniz En az 1 büyük harf, küçük harf, rakam, özel karakter içeren en az 6 haneden oluşmalıdır.  ";
                }
                else
                {
                //Hard code, but better then nothing :)               

                    var res1 = await _userManager.RemovePasswordAsync(currentUser);
                    if (res1.Succeeded)
                    {
                        var res2 = await _userManager.AddPasswordAsync(currentUser, model.Password);
                        if (res2.Succeeded)
                        {
                            model.IsSuccess = true;
                            model.Message = "Şifreniz değişmiştir.";
                        }
                        else
                        {
                            model.IsSuccess = false;
                            model.Message = "Şifreniz güncellenirken beklenmedik bir hata alınmıştır. Bu konuda lütfen sistem yöneticiniz ile irtibata geçiniz!";
                        }
                    }
                    else
                    {
                        model.IsSuccess = false;
                        model.Message = "İşlem başarısız. Lüften tekrar deneyiniz.";
                    }                   
                }
            }
            else
            {
                model.IsSuccess = false;
                
            }
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "Authorize");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
