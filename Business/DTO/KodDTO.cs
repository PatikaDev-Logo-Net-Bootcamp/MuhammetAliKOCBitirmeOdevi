using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class KodDTO
    {
        public KodDTO(int id, string name)
        {
            Id = id;
            Name = name;    
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
