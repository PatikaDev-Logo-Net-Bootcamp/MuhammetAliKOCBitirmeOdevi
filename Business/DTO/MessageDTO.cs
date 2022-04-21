using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string SendUserId { get; set; }
        public string ReceiveUserId { get; set; }
        public string Text { get; set; }
        public bool IsLooked { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public UserDTO SendUserDTO { get; set; }
        public UserDTO ReceiveUserDTO { get; set; }
    }
}
