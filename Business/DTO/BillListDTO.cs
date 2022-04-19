using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BillListDTO
    {
        public BillListDTO()
        {
            Bills = new List<BillDTO>();
        }
        public List<BillDTO> Bills { get; set; }
        public BillDTO Bill { get; set; }
    }
}
