using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlockService
    {
        IQueryable<Block> Blocks();

        ReturnObjectDTO GetBlock(int id);
        ReturnObjectDTO GetAllBlocks();
        ReturnObjectDTO AddBlock(BlockDTO block);

        ReturnObjectDTO UpdateBlock(int id, BlockDTO block, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteBlock(int id, string updatedBy = "Api Kullanicisi");
    }
}
