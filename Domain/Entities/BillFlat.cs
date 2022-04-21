using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BillFlat:BaseEntity
    {
        public int BillId { get; set; }
        public int FlatId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public bool IsPaid { get; set; }
        public DateTime PayTime { get; set; }
        public string PayUserId { get; set; }


        public Bill Bill { get; set; }
        public Flat Flat { get; set; }
    }
}
