using System.Collections.Generic;

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
