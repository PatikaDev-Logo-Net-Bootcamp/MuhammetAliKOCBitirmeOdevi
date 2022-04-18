using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserType:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Flat> UserTypeFlats { get; set; }
    }
}
