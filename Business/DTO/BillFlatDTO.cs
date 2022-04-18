using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BillFlatDTO
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int FlatId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public BillDTO BillDTO { get; set; }
        public FlatDTO FlatDTO { get; set; }
    }
}
