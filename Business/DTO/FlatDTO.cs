using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class FlatDTO
    {
        public FlatDTO()
        {
            BillFlatDTOs = new List<BillFlatDTO>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Kat girilmesi zorunlu!")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "Daire No girilmesi zorunlu!")]
        public string No { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Tip girilmesi zorunlu!")]
        public int FlatTypeId { get; set; }
        public string FlatTypeName { get; set; }

        [Required(ErrorMessage = "Blok girilmesi zorunlu!")]
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public int? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public BillFlatDTO BillFlatDTO { get; set; }
        public List<BillFlatDTO> BillFlatDTOs { get; set; }
    }
}
