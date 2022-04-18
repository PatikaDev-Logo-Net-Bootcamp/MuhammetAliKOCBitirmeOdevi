using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var billEntity = new Bill()
                {
                    Year = bill.Year,
                    Mount = bill.Mount,
                    Description = bill.Description,
                    BillTypeId = bill.BillTypeId,                    
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(billEntity);
                unitOfWork.Commit();

                //bill.Id = billEntity.Id;

                var resData = GetBill(billEntity.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateBill(int id, BillDTO bill, string updatedBy = "Api Kullanicisi")
        {
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


        public ReturnObjectDTO DeleteBill(int id, string updatedBy = "Api Kullanicisi")
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
