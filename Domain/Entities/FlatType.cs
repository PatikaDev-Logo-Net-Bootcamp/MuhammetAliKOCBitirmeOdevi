using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FlatType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Flat> FlatTypeFlats { get; set; }
    }
}
