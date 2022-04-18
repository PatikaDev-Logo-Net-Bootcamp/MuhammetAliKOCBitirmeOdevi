using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BlockService:IBlockService
    {
        private readonly IRepository<Block> repository;
        private readonly IUnitOfWork unitOfWork;
        public BlockService(IRepository<Block> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Block> Blocks()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetBlock(int id)
        {
            var block =  Blocks().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = block, successMessage = "İşlem Başarılı" };
        }

        public List<BlockDTO> GetAllBlocks()
        {
            var blocks =  repository.GetAll().Select(x=>new BlockDTO() {Id=x.Id, Address = x.Address, Description = x.Description, Name = x.Name }).ToList();
            return   blocks ;
        }
        public ReturnObjectDTO AddBlock(BlockDTO block)
        {
            try
            {
                var blockEntity = new Block()
                {
                    Name = block.Name,
                    Address = block.Address,
                    Description = block.Description,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                repository.Add(blockEntity);
                unitOfWork.Commit();

                block.Id = blockEntity.Id;
                return new ReturnObjectDTO() { data = block, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateBlock(int id, BlockDTO block, string updatedBy = "Api Kullanicisi")
        {
            if (id != block.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetBlock(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.Name = block.Name;
            entity.Address = block.Address; 
            entity.Description = block.Description; 

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = block, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteBlock(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetBlock(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Silinecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            try
            {
                repository.Delete(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            } 

        }
     
    }
}
