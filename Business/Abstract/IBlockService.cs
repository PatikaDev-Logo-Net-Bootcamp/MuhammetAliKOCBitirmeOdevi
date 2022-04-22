using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IBlockService
    {
        IQueryable<Block> Blocks();
        ReturnObjectDTO GetBlock(int id);
        List<BlockDTO> GetAllBlocks();
        ReturnObjectDTO AddBlock(BlockDTO block);
        ReturnObjectDTO UpdateBlock(int id, BlockDTO block, string updatedBy = "");
        ReturnObjectDTO DeleteBlock(int id, string updatedBy = "");
    }
}
