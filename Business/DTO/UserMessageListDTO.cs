using System.Collections.Generic;

namespace Business.DTO
{
    public class UserMessageListDTO
    {
        public UserMessageListDTO()
        {
            MessageUsers = new List<UserDTO>();
            Users = new List<UserDTO>();
        }
        public List<UserDTO> MessageUsers { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
