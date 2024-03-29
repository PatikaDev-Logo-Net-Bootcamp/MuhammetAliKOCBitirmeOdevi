﻿using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;  
        private readonly RoleManager<Role> _roleManager;
        private readonly ICarService _carService;


        public UserController(ILogger<UserController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, ICarService carService)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _carService = carService;
        }
 
        public IActionResult IdentityRoleList()
        {
             var model = new UserIdentitiyRoleDTO();
            var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
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
                TC = x.TC,
                Roles = x.UserRoles.Select(y => new RoleDTO() {Id = y.RoleId, Name=y.Role.Name }).ToList()                
            }).ToList();

            model.Users = users;

            var allRoles= _roleManager.Roles.Select(x=>new RoleDTO() { Id = x.Id, Name = x.Name}).ToList();
            ViewBag.AllRoles = allRoles;            
            ViewBag.RoleUserId = allRoles.Where(x => x.Name == "User").FirstOrDefault()?.Id;
            return View(model);
        }

        [HttpPost]
        public JsonResult Get(string UserId)
        {
            var res = new ReturnObjectDTO();

            var model = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x => x.Id == UserId).Select(x => new UserDTO()
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
                TC = x.TC,
                Roles = x.UserRoles.Select(y => new RoleDTO() { Id =  y.Role.Id, Name = y.Role.Name}).ToList()
                
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
            var res = new ReturnObjectDTO();
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
        public async Task<JsonResult> Add(UserIdentitiyRoleDTO userList)
        {

            UserAddDTO user = userList.UserForAdd;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {


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
                        AccessFailedCount = 0,
                        TC = user.TC
                    };
                


                    var userRoleEntity = _roleManager.Roles.Where(x=>x.Id == user.RoleSelected).Select(x=>new UserRole() {User = userEntity, Role =x }).ToList();                         
                    userEntity.UserRoles = userRoleEntity;
                        

                    var createRes = await _userManager.CreateAsync(userEntity,user.Password);

                    if (createRes.Succeeded)
                    {
                            /*var claims = new List<Claim>();
                            claims.Add(new Claim("Id", userEntity.Id));
                            claims.Add(new Claim(ClaimTypes.Name, userEntity.UserName));
                            claims.Add(new Claim("Email", userEntity.Email));
                            claims.Add(new Claim("FirstName", userEntity.FirstName));
                            claims.Add(new Claim("LastName", userEntity.LastName));

                            var claimAddRes =  await _userManager.AddClaimsAsync(userEntity, claims);
                            */

                            if (/*createRes.Succeeded*/true)
                            {
                                res.successMessage = $"{userEntity.FirstName} {userEntity.LastName} başarıyla eklenmiştir.";
                                res.data = userEntity.Id;
                            }
                            else
                            {
                                await _userManager.DeleteAsync(userEntity);   
                                res.isSuccess = false;
                                res.errorMessage = "Kullanıcı Oluştururken HATA ALINMIŞTIR.(Claims)";
                            }


                         
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

            }
            else
            {
                res.isSuccess=false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<JsonResult> Update(UserIdentitiyRoleDTO userList)
        {
            UserUpdateDTO user = userList.UserForUpdate;
            var res = new ReturnObjectDTO();
            if (ModelState.IsValid)
            {
                try
            {
                if (string.IsNullOrEmpty(user.Id))//Güncellenen kaydın id alanı boş olamaz!
                {
                    res.isSuccess = false;
                    res.errorMessage = "Kullanıcı kimlik bilgisi bulunamamıştır!";
                }
                else//update işlemi
                {
                    var userEntity = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x => x.Id == user.Id).FirstOrDefault();
                    if (userEntity != null)
                    {
                        userEntity.FirstName = user.FirstName;
                        userEntity.LastName = user.LastName;
                        userEntity.Email = user.Email;
                        userEntity.PhoneNumber = user.PhoneNumber;
                        userEntity.UserName = user.UserName;
                        userEntity.TC = user.TC;
                        
                       var userRoleEntity = _roleManager.Roles.Where(x => x.Id == user.RoleSelected).Select(x => new UserRole() { User = userEntity, Role = x }).ToList();
                       
                       userEntity.UserRoles = userRoleEntity;


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

            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        public IActionResult UserCarList()
        {
            var model = new UserCarDTO();
            var users = _userManager.Users.Include(u => u.UserCars)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Cars = x.UserCars.Select(y => new CarDTO() { Id = y.Id, Aciklama = y.Aciklama, Plaka = y.Plaka }).ToList()

                }).ToList();

            model.Users = users;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddCar(UserCarDTO userList)
        {
            CarDTO car = userList.CarForAddUpdate;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _carService.AddCar(car);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetCar(int id)
        {  
            var res = _carService.GetCar(id); 

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateCar(UserCarDTO userList)
        {
            CarDTO car = userList.CarForAddUpdate;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _carService.UpdateCar(car.Id,car);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteCar(int id)
        {
            var res = _carService.DeleteCar(id);

            return new JsonResult(res);
        }
    }
}
