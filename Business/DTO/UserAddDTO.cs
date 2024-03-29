﻿using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class UserAddDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Ad girilmesi zorunlu!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad girilmesi zorunlu!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "KullanıcıAdı girilmesi zorunlu!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email girilmesi zorunlu!")]
        [EmailAddress(ErrorMessage ="Email hatalı!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunlu!")] 
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage ="Şifre en az 1 küçük harf, 1 büyük harf, 1 rakam ve bir sembolden oluşan en az 6 karakterlik bir ifade olmalıdır!")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleSelected { get; set; }
        public string TC { get; set; }

    }
}
