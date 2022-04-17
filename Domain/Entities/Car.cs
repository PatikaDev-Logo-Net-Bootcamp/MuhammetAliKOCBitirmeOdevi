using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car: BaseEntity
    {
        public string Aciklama { get; set; }
        public string Plaka { get; set; }

        public virtual User User { get; set; }
    }
}
