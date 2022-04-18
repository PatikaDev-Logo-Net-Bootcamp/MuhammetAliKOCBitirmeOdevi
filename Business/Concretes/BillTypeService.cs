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
    public class BillTypeService:IBillTypeService
    {
        private readonly IRepository<BillType> repository;
        private readonly IUnitOfWork unitOfWork;
        public BillTypeService(IRepository<BillType> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<BillType> BillTypes()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetBillType(int id)
        {
            var billType =  BillTypes().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = billType, successMessage = "İşlem Başarılı" };
        }

        public List<BillTypeDTO> GetAllBillTypes()
        {
            var billTypes =  repository.GetAll().Select(x=>new BillTypeDTO() { Id = x.Id, Name = x.Name}).ToList();
            return billTypes;
        }
        public ReturnObjectDTO AddBillType(BillTypeDTO billType)
        {
            try
            {
                var billTypeEntity = new BillType()
                {
                    Name = billType.Name,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                repository.Add(billTypeEntity);
                unitOfWork.Commit();

                billType.Id = billTypeEntity.Id;
                return new ReturnObjectDTO() { data = billType, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateBillType(int id, BillTypeDTO billType, string updatedBy = "Api Kullanicisi")
        {
            if (id != billType.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetBillType(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.Name = billType.Name;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = billType, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteBillType(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetBillType(id);
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
