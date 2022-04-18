using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class FlatDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kat girilmesi zorunlu!")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "Daire No girilmesi zorunlu!")]
        public string No { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Tip girilmesi zorunlu!")]

        public int FlatTypeId { get; set; }
        public string FlatTypeName { get; set; }

        //public FlatType FlatType { get; set; }

        [Required(ErrorMessage = "Blok girilmesi zorunlu!")]
        public int BlockId { get; set; }
        public string BlockName { get; set; }

        //public Block Block { get; set; }

        public string? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        //public User User { get; set; }

        public int? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        //public UserType UserType { get; set; }
    }
}
