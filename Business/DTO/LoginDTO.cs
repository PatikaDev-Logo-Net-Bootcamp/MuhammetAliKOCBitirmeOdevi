using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class LoginDTO
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir Email adresi giriniz.")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
