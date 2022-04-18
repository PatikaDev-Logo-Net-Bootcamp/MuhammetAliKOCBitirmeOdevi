using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class FlatListDTO
    {
        public FlatListDTO()
        {
            Flats = new List<FlatDTO>();
        }
        public List<FlatDTO> Flats { get; set; }

        public FlatDTO Flat { get; set; }
    }
}
