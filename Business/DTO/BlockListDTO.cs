using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BlockListDTO
    {
        public BlockListDTO()
        {
            Blocks = new List<BlockDTO>();
        }
        public List<BlockDTO> Blocks { get; set; }

        public BlockDTO Block { get; set; }
    }
}
