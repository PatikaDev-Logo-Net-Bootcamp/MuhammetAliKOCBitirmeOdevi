using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserIdentitiyRoleDTO
    {
        public UserIdentitiyRoleDTO()
        {
            Users = new List<UserDTO>();
        }
        public List<UserDTO> Users { get; set; }
        public UserAddDTO UserForAdd { get; set; }
        public UserUpdateDTO UserForUpdate { get; set; }

   
    }
}
