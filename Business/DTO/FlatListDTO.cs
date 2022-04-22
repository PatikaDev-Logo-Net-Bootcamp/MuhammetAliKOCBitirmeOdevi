using System.Collections.Generic;

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
