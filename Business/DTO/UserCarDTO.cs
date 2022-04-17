using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
