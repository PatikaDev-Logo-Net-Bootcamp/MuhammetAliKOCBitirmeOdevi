using System.Collections.Generic;

namespace Business.DTO
{
    public class UserCarDTO
    {
        public UserCarDTO()
        {
            Users = new List<UserDTO>();
        }
        public List<UserDTO> Users { get; set; }
        public CarDTO CarForAddUpdate { get; set; }

    }
}
