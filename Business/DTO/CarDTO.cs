using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Açıklama girilmesi zorunlu!")]
        public string Aciklama { get; set; }
        public string Plaka { get; set; }
        public string UserId { get; set; }
    }
}
