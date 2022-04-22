using System;
using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tip girilmesi zorunlu!")]
        [Range(2, int.MaxValue, ErrorMessage = "Tip Alanı Geçerli Bir Alan Olmalıdır.")]
        public int BillTypeId { get; set; }
  
        public string BillTypeName { get; set; }
        [Required(ErrorMessage = "Yıl girilmesi zorunlu!")]
        [Range(1, int.MaxValue, ErrorMessage = "Yıl Alanı Geçerli Bir Alan Olmalıdır.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Ay girilmesi zorunlu!")]
        [Range(1, 12, ErrorMessage = "Ay Alanı Geçerli Bir Alan Olmalıdır.")]
        public int Mount { get; set; }
        public string Description { get; set; }
 
    }
}
