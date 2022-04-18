﻿using Business.Abstract;
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
    public class FlatService:IFlatService
    {
        private readonly IRepository<Flat> repository;
        private readonly IUnitOfWork unitOfWork;
        public FlatService(IRepository<Flat> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Flat> Flats()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetFlat(int id)
        {
            var flat =  Flats().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = flat, successMessage = "İşlem Başarılı" };
        }

        public ReturnObjectDTO GetAllFlats()
        {
            var flats =  repository.GetAll().ToList();
            return new ReturnObjectDTO() { data = flats };
        }
        public ReturnObjectDTO AddFlat(FlatDTO flat)
        {
            try
            {
                var flatEntity = new Flat()
                {                    
                    Floor = flat.Floor,
                    No = flat.No,
                    Description = flat.Description,
                    FlatTypeId = flat.FlatTypeId,
                    BlockId=flat.BlockId,
                    UserId = flat.UserId,
                    UserTypeId = flat.UserTypeId,
                    DateCreated = DateTime.Now, 
                    IsActive = true
                };

                repository.Add(flatEntity);
                unitOfWork.Commit();

                flat.Id = flatEntity.Id;
                return new ReturnObjectDTO() { data = flat, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateFlat(int id, FlatDTO flat, string updatedBy = "Api Kullanicisi")
        {
            if (id != flat.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetFlat(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

                    entity.Floor = flat.Floor;
                    entity.No = flat.No;
                    entity.Description = flat.Description;
                    entity.FlatTypeId = flat.FlatTypeId;
                    entity.BlockId = flat.BlockId;
                    entity.UserId = flat.UserId;
                    entity.UserTypeId = flat.UserTypeId;
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = flat, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteFlat(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetFlat(id);
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