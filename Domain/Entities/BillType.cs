using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BillType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
