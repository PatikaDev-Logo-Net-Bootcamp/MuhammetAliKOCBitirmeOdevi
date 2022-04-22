using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concretes
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill> repository;
        private readonly IUnitOfWork unitOfWork;
        public BillService(IRepository<Bill> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Bill> Bills()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetBill(int id)
        {
            var bill = Bills().Include(u => u.BillType)
                .Select(x => new BillDTO()
                {
                    Id = x.Id,
                    Year = x.Year,
                    Mount = x.Mount,
                    Description = x.Description,
                    BillTypeId = x.BillTypeId,
                    BillTypeName = x.BillType.Name
                     
                }).FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = bill, successMessage = "İşlem Başarılı" };
        }

        public List<BillDTO> GetAllBills()
        {
            var bills = repository.GetAllEntities().Include(u => u.BillType)

                .Select(x => new BillDTO()
                {
                    Id = x.Id,
                    Year = x.Year,
                    Mount = x.Mount,
                    Description = x.Description,
                    BillTypeId = x.BillTypeId,
                    BillTypeName = x.BillType.Name
                }).ToList();
            return bills;
        }
        public ReturnObjectDTO AddBill(BillDTO bill)
        {
            try
            {
                var bilKontrolEntity = GetAllBills().Where(x=>x.Year == bill.Year && x.Mount ==bill.Mount && x.BillTypeId == bill.BillTypeId).FirstOrDefault();
                if (bilKontrolEntity!=null)
                {
                    return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Bu fatura daha önce Girilmiş. Lütfen Kontrol Ediniz!" };
                }

                var billEntity = new Bill()
                {
                    Year = bill.Year,
                    Mount = bill.Mount,
                    Description = bill.Description??"",
                    BillTypeId = bill.BillTypeId,                    
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(billEntity);
                unitOfWork.Commit();

                var resData = GetBill(billEntity.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO UpdateBill(int id, BillDTO bill, string updatedBy = "")
        {
            var bilKontrolEntity = GetAllBills().Where(x => x.Id!=bill.Id && x.Year == bill.Year && x.Mount == bill.Mount && x.BillTypeId == bill.BillTypeId).FirstOrDefault();
            if (bilKontrolEntity != null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Aynı Yıl,Ay,Tip e sahip yanlızca 1 fatura olabilir. Lütfen Kontrol Ediniz!" };
            }

            if (id != bill.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetBill(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.BillTypeId = bill.BillTypeId;
            entity.Year = bill.Year;
            entity.Description = bill.Description;
            entity.Mount = bill.Mount;
 
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                var resData = GetBill(bill.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO DeleteBill(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);//GetBill(id);
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
