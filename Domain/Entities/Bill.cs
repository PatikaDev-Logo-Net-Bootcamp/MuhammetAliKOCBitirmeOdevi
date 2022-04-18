using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bill:BaseEntity
    {
        public int BillTypeId { get; set; }
        public int Year { get; set; }
        public int Mount { get; set; }
        public string Description { get; set; }
        public BillType BillType { get; set; }

        public ICollection<BillFlat> BillFlats { get; set; }
    }
}
