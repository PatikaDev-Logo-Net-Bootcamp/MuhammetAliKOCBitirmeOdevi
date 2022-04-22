using System;
using System.Collections.Generic;

namespace Business.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Roles=new List<RoleDTO>();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string TC { get; set; }
        public string Description { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public MessageDTO LastMessageDTO { get; set; }
        public DateTime LastMessageDate { get; set; }
        public int UnLookedMessagesCount { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public UserAddDTO UserAddModel { get; set; }
        public List<CarDTO> Cars { get; set; }

    }
}
