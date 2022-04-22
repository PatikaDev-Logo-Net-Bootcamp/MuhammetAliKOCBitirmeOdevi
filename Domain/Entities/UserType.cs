using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Flat> UserTypeFlats { get; set; }
    }
}
