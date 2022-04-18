using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BlockDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad girilmesi zorunlu!")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
