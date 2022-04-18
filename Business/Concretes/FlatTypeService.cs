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
    public class FlatTypeService:IFlatTypeService
    {
        private readonly IRepository<FlatType> repository;
        private readonly IUnitOfWork unitOfWork;
        public FlatTypeService(IRepository<FlatType> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<FlatType> FlatTypes()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetFlatType(int id)
        {
            var flatType =  FlatTypes().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = flatType, successMessage = "İşlem Başarılı" };
        }

        public ReturnObjectDTO GetAllFlatTypes()
        {
            var flatTypes =  repository.GetAll().ToList();
            return new ReturnObjectDTO() { data = flatTypes };
        }
        public ReturnObjectDTO AddFlatType(FlatTypeDTO flatType)
        {
            try
            {
                var flatTypeEntity = new FlatType()
                {
                    Name = flatType.Name,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                repository.Add(flatTypeEntity);
                unitOfWork.Commit();

                flatType.Id = flatTypeEntity.Id;
                return new ReturnObjectDTO() { data = flatType, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateFlatType(int id, FlatTypeDTO flatType, string updatedBy = "Api Kullanicisi")
        {
            if (id != flatType.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetFlatType(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.Name = flatType.Name;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = flatType, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteFlatType(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetFlatType(id);
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
