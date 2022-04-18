using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int BillTypeId { get; set; }

        public string BillTypeName { get; set; }
        public int Year { get; set; }
        public int Mount { get; set; }
        public string Description { get; set; }
 
    }
}
