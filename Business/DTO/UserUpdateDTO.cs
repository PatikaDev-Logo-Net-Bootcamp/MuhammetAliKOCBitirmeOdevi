using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserUpdateDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Ad girilmesi zorunlu!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad girilmesi zorunlu!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "KullanıcıAdı girilmesi zorunlu!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email girilmesi zorunlu!")]
        [EmailAddress(ErrorMessage = "Email hatalı!")]
        public string Email { get; set; }
 
        public string PhoneNumber { get; set; }
        public string RoleSelected { get; set; }

        public string TC { get; set; }
    }
}
