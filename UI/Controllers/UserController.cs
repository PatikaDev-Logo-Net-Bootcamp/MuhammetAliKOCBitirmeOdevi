using Business.DTO;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,Manager")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<User> _roleManager;


        public UserController(ILogger<UserController> logger, UserManager<User> userManager, SignInManager<User> signInManager/* , RoleManager<User> roleManager*/)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            /*_roleManager = roleManager;*/
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

        public IActionResult List()
        {
            var model = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Select(x => new UserDTO()
            {
                Id = x.Id,
                UserName = x.UserName,
                AccessFailedCount = x.AccessFailedCount,
                ConcurrencyStamp = x.ConcurrencyStamp,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LockoutEnabled = x.LockoutEnabled,
                PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                LockoutEnd = x.LockoutEnd,
                NormalizedEmail = x.NormalizedEmail,
                NormalizedUserName = x.NormalizedUserName,
                PhoneNumber = x.PhoneNumber,
                PictureUrl = x.PictureUrl,
                TwoFactorEnabled = x.TwoFactorEnabled,
                SecurityStamp = x.SecurityStamp,
                Roles = x.UserRoles.Select(y => new RoleDTO() {Id = y.RoleId, Name=y.Role.Name }).ToList()
                //UserEntity = x
                
            }).ToList();

                //foreach (var usr in model)
                //{
                //    usr.Roles = _userManager.GetRolesAsync(usr.UserEntity).Result.ToList();
                //    usr.UserEntity = null;
                //}

            return View(model);
        }

        [HttpPost]
        public JsonResult Get(string UserId)
        {
            var res = new ReturnObject();

            var model = _userManager.Users.Where(x => x.Id == UserId).Select(x => new UserDTO()
            {
                Id=x.Id,
                UserName = x.UserName,
                AccessFailedCount = x.AccessFailedCount,
                ConcurrencyStamp = x.ConcurrencyStamp,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LockoutEnabled = x.LockoutEnabled,
                PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                LockoutEnd = x.LockoutEnd,
                NormalizedEmail = x.NormalizedEmail,
                NormalizedUserName = x.NormalizedUserName,
                PhoneNumber = x.PhoneNumber,
                PictureUrl = x.PictureUrl,
                TwoFactorEnabled = x.TwoFactorEnabled,
                SecurityStamp = x.SecurityStamp,
            }).FirstOrDefault();

            if (model == null)
            {
                res.isSuccess = false;
                res.errorMessage = "Kullanıcı bulunamadı.";
            }
            else
            {
                res.data = model;
            }

            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string UserId)
        {
            var res = new ReturnObject();

            try
            {
                var model = _userManager.Users.Where(x => x.Id == UserId).FirstOrDefault();
                if (model != null)
                {
                    await _userManager.DeleteAsync(model);
                    res.successMessage = "Silme İşlemi Başarıyla Gerçekleştirilmiştir.";
                }
                else
                {
                    res.isSuccess = false;
                    res.errorMessage = "Kullanıcı bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                res.isSuccess = false;
                res.errorMessage = "Silme işlemi sırasında HATA ALINMIŞTIR. Lütfen tekrar deneyiniz. Hata almaya devam ederseniz; Lütfen sistem yöneticinizle iletişime geçiniz.";
            }

            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<JsonResult> Add(UserAddDTO user)
        {

            
            var res = new ReturnObject();

            try
            {
                if (string.IsNullOrEmpty(user.Id))//Yeni kullanıcı ekleme işlemi
                {
                    var userEntity = new User()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,   
                        PictureUrl = "",
                        Email = user.Email,
                        NormalizedEmail = user.Email.Normalize(),
                        UserName = user.UserName,
                        NormalizedUserName = user.UserName.Normalize(),
                        EmailConfirmed=false,
                        SecurityStamp = "",
                        ConcurrencyStamp="",
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    };
                    var createRes = await _userManager.CreateAsync(userEntity,user.Password);
                    if (createRes.Succeeded)
                    {
                        res.successMessage = $"{userEntity.FirstName} {userEntity.LastName} başarıyla eklenmiştir.";
                        res.data = userEntity.Id;
                    }
                    else
                    {
                        res.isSuccess = false;
                        res.errorMessage = "Kullanıcı Oluştururken HATA ALINMIŞTIR.";
                    }
                }
                else//Eklenen kaydın id alanı boş gelmeliydi. Dolu geliyorsa bu güncelleme olmalıydı; ekleme değil.
                {                     
                        res.isSuccess = false;
                        res.errorMessage = "Bu kullanıcı daha önce eklenmiş. Lütfen kullanıcı bilgilerini kontrol ederek işleminizi yeniden deneyiniz.";                   
                }

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                res.isSuccess = false;
                res.errorMessage = "İşlem sırasında HATA ALINMIŞTIR. Lütfen tekrar deneyiniz. Hata almaya devam ederseniz; Lütfen sistem yöneticinizle iletişime geçiniz.";
            }

            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<JsonResult> Update(UserDTO user)
        {
            var res = new ReturnObject();

            try
            {
                if (string.IsNullOrEmpty(user.Id))//Güncellenen kaydın id alanı boş olamaz!
                {
                    res.isSuccess = false;
                    res.errorMessage = "Kullanıcı kimlik bilgisi bulunamamıştır!";
                }
                else//update işlemi
                {
                    var userEntity = _userManager.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                    if (userEntity != null)
                    {
                        userEntity.FirstName = user.FirstName;
                        userEntity.LastName = user.LastName;
                        userEntity.Email = user.Email;
                        userEntity.PhoneNumber = user.PhoneNumber;
                        userEntity.UserName = user.UserName;
                        var updateRes = await _userManager.UpdateAsync(userEntity);

                        if (updateRes.Succeeded)
                        {
                            res.successMessage = $"{userEntity.FirstName} {userEntity.LastName} bilgileri başarıla güncellenmiştir.";
                        }
                        else
                        {
                            res.isSuccess = false;
                            res.errorMessage = "Kullanıcı Güncellerken HATA ALINMIŞTIR.";
                        }
                    }
                    else
                    {
                        res.isSuccess = false;
                        res.errorMessage = "Kullanıcı bulunamadı.";
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                res.isSuccess = false;
                res.errorMessage = "İşlem sırasında HATA ALINMIŞTIR. Lütfen tekrar deneyiniz. Hata almaya devam ederseniz; Lütfen sistem yöneticinizle iletişime geçiniz.";
            }

            return new JsonResult(res);
        }

 
 
    }
}
