using System.Collections.Generic;

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
