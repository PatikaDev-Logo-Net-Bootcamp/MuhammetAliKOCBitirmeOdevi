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

        public int FlatTypeId { get; set; }

        //public FlatType FlatType { get; set; }

        public int BlockId { get; set; }

        //public Block Block { get; set; }

        public string? UserId { get; set; }
        //public User User { get; set; }

        public int? UserTypeId { get; set; }
        //public UserType UserType { get; set; }
    }
}
