using Domain.Base;
using System.Collections.Generic;

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
