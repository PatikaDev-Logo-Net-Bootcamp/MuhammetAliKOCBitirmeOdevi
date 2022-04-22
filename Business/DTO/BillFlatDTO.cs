using System;
using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class BillFlatDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fatura alanı zorunlu!")]
        public int BillId { get; set; }
        [Required(ErrorMessage = "Daire alanı zorunlu!")]
        public int FlatId { get; set; }
        [DataType(DataType.Currency,ErrorMessage ="Değer Geçersiz.")]
        [Required(ErrorMessage = "Fatura değeri girilmesi zorunlu!")]
        //[Range(0.0000000000001, Double.MaxValue, ErrorMessage = "Fatura değeri 0'dan büyük bir sayı olmalıdır.")]
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PayTime { get; set; }
        public string PayUserId { get; set; }
        public BillDTO BillDTO { get; set; }
        public FlatDTO FlatDTO { get; set; }
    }
}
