using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
