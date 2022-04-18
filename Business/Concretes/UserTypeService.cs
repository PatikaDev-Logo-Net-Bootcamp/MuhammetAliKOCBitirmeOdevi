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
    public class UserTypeService:IUserTypeService
    {
        private readonly IRepository<UserType> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserTypeService(IRepository<UserType> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<UserType> UserTypes()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetUserType(int id)
        {
            var userType =  UserTypes().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = userType, successMessage = "İşlem Başarılı" };
        }

        public List<UserTypeDTO> GetAllUserTypes()
        {
            var userTypes =  repository.GetAll().Select(x=>new UserTypeDTO() { Id = x.Id, Name = x.Name}).ToList();
            return userTypes;
        }
        public ReturnObjectDTO AddUserType(UserTypeDTO userType)
        {
            try
            {
                var userTypeEntity = new UserType()
                {
                    Name = userType.Name,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                repository.Add(userTypeEntity);
                unitOfWork.Commit();

                userType.Id = userTypeEntity.Id;
                return new ReturnObjectDTO() { data = userType, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateUserType(int id, UserTypeDTO userType, string updatedBy = "Api Kullanicisi")
        {
            if (id != userType.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetUserType(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.Name = userType.Name;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = userType, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteUserType(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetUserType(id);
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
