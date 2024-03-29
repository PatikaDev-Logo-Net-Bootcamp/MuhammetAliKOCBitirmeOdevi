﻿using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _messageService;
        private readonly UserManager<User> _userManager;

        public MessageController(ILogger<MessageController> logger, IMessageService messageService, UserManager<User> userManager)
        {
            _logger = logger;
            _messageService = messageService;
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var model = new UserMessageListDTO();

            var currentUser = _userManager.GetUserAsync(User).Result;            

            var messagedUsers = _userManager.Users.Where(x => x.Id != currentUser.Id && ((x.ReceivedMessages.Count(y => y.SendUserId == currentUser.Id) > 0 || (x.SendedMessages.Count(y => y.ReceiveUserId == currentUser.Id) > 0)))).Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                LastMessageDate = _messageService.Messages().Where(m=>(m.SendUserId == x.Id && m.ReceiveUserId == currentUser.Id) || (m.SendUserId == currentUser.Id && m.ReceiveUserId == x.Id)).OrderByDescending(m=>m.DateCreated).FirstOrDefault().DateCreated,             

                UnLookedMessagesCount = _messageService.Messages().Where(m => m.SendUserId == x.Id && m.ReceiveUserId == currentUser.Id && m.IsLooked==false).Count()
            }).OrderBy(x=>x.LastMessageDate).ThenBy(x=>x.UnLookedMessagesCount).ToList();

            model.MessageUsers = messagedUsers;

            var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x=>x.Id !=currentUser.Id)
          .Select(x => new UserDTO()
          {
              Id = x.Id,
              UserName = x.UserName,               
              Email = x.Email,
              FirstName = x.FirstName,
              LastName = x.LastName,              
              PhoneNumber = x.PhoneNumber,
              PictureUrl = x.PictureUrl,             
              Roles = x.UserRoles.Select(y => new RoleDTO() { Id = y.RoleId, Name = y.Role.Name }).ToList()
                }).ToList();

            model.Users = users;

            return View(model);
        }

        [HttpPost]
        public JsonResult Messages(string chatuserid)
        {          
            var currentUser = _userManager.GetUserAsync(User).Result;
            var model = _messageService.GetMessages(currentUser.Id, chatuserid);
            //burada gönderilen mesajın okundu bilgisi 1 yapılmalı.
            var unlooks = ((List<MessageDTO>)model.data).Where(x=>x.IsLooked==false).ToList();
            foreach (var item in unlooks)
            {
                _messageService.UpdateMessageAsLooked(item.Id);
            }

            return new JsonResult(model);
        }

        [HttpPost]
        public JsonResult AddMessage(string receiverUserId, string text)
        {
            if (receiverUserId == null || text==null)
            {
                return new JsonResult(new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Hatalı parametre!" });
            }

            var currentUser = _userManager.GetUserAsync(User).Result;

            var model = new MessageDTO() { SendUserId = currentUser.Id, ReceiveUserId = receiverUserId, Text = text, DateCreated= DateTime.Now, IsLooked=false };

            var res = _messageService.AddMessage(model);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult ChatUserSessionMessages(string chatUserId, int chatuserlastmessageid)
        {
            //burada gönderilen mesajın okundu bilgisi 1 yapılmalı.
            if (chatUserId == null)
            {
                return new JsonResult(new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Hatalı parametre!" });
            }

            var currentUser = _userManager.GetUserAsync(User).Result;           

            var res = _messageService.GetMessagesWithConditions(currentUser.Id, chatUserId, chatuserlastmessageid);

            //burada gönderilen mesajın okundu bilgisi 1 yapılmalı.
            var unlooks = ((List<MessageDTO>)res.data).Where(x => x.IsLooked == false).ToList();
            foreach (var item in unlooks)
            {
                _messageService.UpdateMessageAsLooked(item.Id);
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetUnLookedMessageCountForUser()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;

            var count = _messageService.GetUnLookedMessageCountForUser(currentUser.Id); 

            return new JsonResult(count);
        }


    }
}
