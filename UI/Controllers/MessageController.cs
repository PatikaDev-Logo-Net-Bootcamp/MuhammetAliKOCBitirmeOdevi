using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
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
            var currentUser = _userManager.GetUserAsync(User).Result;

            //var model = (from userDTO in _userManager.Users.Select(x => new UserDTO()
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    UserName = x.UserName,
            //    Email = x.Email
            //})
            //              join m in _messageService.Messages().Where(x=>x.ReceiveUserId==currentUser.Id || x.SendUserId==currentUser.Id).Select(x => new MessageDTO()
            //              {
            //                  Id = x.Id,
            //                  Text = x.Text,
            //                  DateCreated = x.DateCreated,
            //                  IsLooked = x.IsLooked,
            //                  IsActive = x.IsActive,
            //                  ReceiveUserId = x.ReceiveUserId,
            //                  SendUserId = x.SendUserId
            //              })

            //              on userDTO.Id equals m.ReceiveUserId
            //              into MessageGroup
            //              select userDTO);



       

            var model = _userManager.Users.Where(x => x.ReceivedMessages.Any(y => y.ReceiveUserId == x.Id || y.SendUserId == x.Id)).Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email
            }).ToList();



          /*  .Select(x => new UserDTO()
             {
                 Id = x.Id,
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                 UserName = x.UserName,
                 Email = x.Email
             })*/

            //.Where(x => x.ReceiveUserId == currentUser.Id || x.SendUserId == currentUser.Id).Select(x => new MessageDTO()
            // {
            //     Id = x.Id,
            //     Text = x.Text,
            //     DateCreated = x.DateCreated,
            //     IsLooked = x.IsLooked,
            //     IsActive = x.IsActive,
            //     ReceiveUserId = x.ReceiveUserId,
            //     SendUserId = x.SendUserId
            // })




            return View(model);
        }

        [HttpPost]
        public IActionResult Messages(string senderuserid)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;

            var result = (from userDTO in _userManager.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email
            })
                          join m in _messageService.Messages().Where(x => x.ReceiveUserId == currentUser.Id && x.SendUserId == senderuserid).Select(x => new MessageDTO()
                          {
                              Id = x.Id,
                              Text = x.Text,
                              DateCreated = x.DateCreated,
                              IsLooked = x.IsLooked,
                              IsActive = x.IsActive,
                              ReceiveUserId = x.ReceiveUserId,
                              SendUserId = x.SendUserId
                          })

                          on userDTO.Id equals m.ReceiveUserId
                          into MessageGroup
                          select new
                          {
                              SenderUserDTO = userDTO,
                              Message = MessageGroup
                          }).FirstOrDefault();

            return View();
        }

 
    }
}
