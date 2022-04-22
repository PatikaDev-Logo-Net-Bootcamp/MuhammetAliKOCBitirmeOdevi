using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Block:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<Flat> BlockFlats { get; set; }
    }
}
