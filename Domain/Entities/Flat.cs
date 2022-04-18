using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Flat:BaseEntity
    {
        public int Floor { get; set; }

        public string No { get; set; }

        public string Description { get; set; }

        public int FlatTypeId { get; set; }

        public FlatType FlatType { get; set; }

        public int BlockId { get; set; }

        public Block Block { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int? UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public ICollection<BillFlat> BillFlats { get; set; }

    }
}
