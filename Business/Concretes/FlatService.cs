﻿using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concretes
{
    public class FlatService : IFlatService
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
        public IQueryable<FlatDTO> FlatDTOs()
        {
            return repository.GetAll().Include(b => b.Block).Include(u => u.FlatType).Include(ur => ur.UserType).Include(usr => usr.User).Include(x => x.BillFlats)
                .Select(x => new FlatDTO()
                {
                    Id = x.Id,
                    BlockId = x.BlockId,
                    BlockName = x.Block.Name,
                    Description = x.Description,
                    No = x.No,
                    FlatTypeId = x.FlatTypeId,
                    FlatTypeName = x.FlatType.Name,
                    Floor = x.Floor,
                    UserId = x.UserId,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserPhoneNumber = x.User.PhoneNumber,
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserType.Name,
                    BillFlatDTOs = x.BillFlats.Select(y => new BillFlatDTO() { Id = y.Id, BillId = y.BillId, FlatId = y.FlatId, Amount = y.Amount}).ToList()    

                }) ;
        }
        public IQueryable<FlatDTO> FlatDTOsByBillId(int billId)
        {
            return repository.GetAll().Include(b => b.Block).Include(u => u.FlatType).Include(ur => ur.UserType).Include(usr => usr.User).Include(x => x.BillFlats)
                .Select(x => new FlatDTO()
                {
                    Id = x.Id,
                    BlockId = x.BlockId,
                    BlockName = x.Block.Name,
                    Description = x.Description,
                    No = x.No,
                    FlatTypeId = x.FlatTypeId,
                    FlatTypeName = x.FlatType.Name,
                    Floor = x.Floor,
                    UserId = x.UserId,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserPhoneNumber = x.User.PhoneNumber,
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserType.Name,
                    BillFlatDTO = x.BillFlats.Where(y=>y.BillId == billId).Select(y => new BillFlatDTO() { Id = y.Id, BillId = y.BillId, FlatId = y.FlatId, Amount = y.Amount , Description = y.Description, BillDTO= new BillDTO() { Id = y.Bill.Id, Year=y.Bill.Year, Mount=y.Bill.Mount, Description = y.Bill.Description, BillTypeId = y.Bill.BillTypeId,BillTypeName = y.Bill.BillType.Name } }).FirstOrDefault()

                });
        }
        public ReturnObjectDTO GetFlat(int id)
        {
            var flat = Flats().Include(b => b.Block).Include(u => u.FlatType).Include(ur => ur.UserType).Include(usr => usr.User)
                .Select(x => new FlatDTO()
                {
                    Id = x.Id,
                    BlockId = x.BlockId,
                    BlockName = x.Block.Name,
                    Description = x.Description,
                    No = x.No,
                    FlatTypeId = x.FlatTypeId,
                    FlatTypeName = x.FlatType.Name,
                    Floor = x.Floor,
                    UserId = x.UserId,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserPhoneNumber = x.User.PhoneNumber,
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserType.Name
                }).FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = flat, successMessage = "İşlem Başarılı" };
        }
        public List<FlatDTO> GetAllFlats()
        {
            var flats = repository.GetAllEntities().Include(b => b.Block).Include(u => u.FlatType).Include(ur => ur.UserType).Include(usr => usr.User)

                .Select(x => new FlatDTO()
                {
                    Id = x.Id,
                    BlockId = x.BlockId,
                    BlockName = x.Block.Name,
                    Description = x.Description,
                    No = x.No,
                    FlatTypeId = x.FlatTypeId,
                    FlatTypeName = x.FlatType.Name,
                    Floor = x.Floor,
                    UserId = x.UserId,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    UserPhoneNumber = x.User.PhoneNumber,
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserType.Name
                }).ToList();
            return flats;
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
                    BlockId = flat.BlockId,
                    UserId = flat.UserId,
                    UserTypeId = flat.UserTypeId,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(flatEntity);
                unitOfWork.Commit();

                //flat.Id = flatEntity.Id;

                var resData = GetFlat(flatEntity.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO UpdateFlat(int id, FlatDTO flat, string updatedBy = "")
        {
            if (id != flat.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);
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
                var resData = GetFlat(flat.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO DeleteFlat(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);
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
