using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class ResetPasswordDTO

    {
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string RePassword { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
