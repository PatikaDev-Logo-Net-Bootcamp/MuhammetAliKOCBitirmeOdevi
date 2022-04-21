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
    public class BillFlatService : IBillFlatService
    {
        private readonly IRepository<BillFlat> repository;
        private readonly IUnitOfWork unitOfWork;
        public BillFlatService(IRepository<BillFlat> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<BillFlat> BillFlats()
        {
            return repository.GetAll();
        }

        public ReturnObjectDTO GetBillFlat(int id)
        {
            var billFlat = BillFlats().Include(u => u.Bill).ThenInclude(u => u.BillType).Include(u => u.Flat).ThenInclude(u => u.Block).Include(u => u.Flat).ThenInclude(u => u.User).Include(u => u.Flat).ThenInclude(u => u.UserType)
                .Select(x => new BillFlatDTO()
                {
                    Id = x.Id,
                    BillId = x.BillId,
                    FlatId = x.FlatId,
                    Description = x.Description,
                    Amount = x.Amount,
                    BillDTO = new BillDTO()
                    {
                        Id = x.Bill.Id
                                            ,
                        BillTypeId = x.Bill.BillTypeId
                                            ,
                        BillTypeName = x.Bill.BillType.Name
                                            ,
                        Description = x.Bill.Description
                                            ,
                        Mount = x.Bill.Mount
                                            ,
                        Year = x.Bill.Year
                    },
                    FlatDTO = new FlatDTO()
                    {
                        Id = x.Flat.Id,
                        BlockId = x.Flat.BlockId,
                        BlockName = x.Flat.Block.Name,
                        Description = x.Flat.Description,
                        FlatTypeId = x.Flat.FlatTypeId,
                        FlatTypeName = x.Flat.FlatType.Name,
                        Floor = x.Flat.Floor,
                        No = x.Flat.No,
                        UserId = x.Flat.UserId,
                        UserEmail = x.Flat.User.Email,
                        UserFirstName = x.Flat.User.FirstName,
                        UserLastName = x.Flat.User.LastName,
                        UserPhoneNumber = x.Flat.User.PhoneNumber,
                        UserTypeId = x.Flat.UserTypeId,
                        UserTypeName = x.Flat.UserType.Name
                    }

                }).FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = billFlat, successMessage = "İşlem Başarılı" };
        }

        public List<BillFlatDTO> GetAllBillFlats()
        {
            var billFlats = repository.GetAllEntities().Include(u => u.Bill).ThenInclude(u => u.BillType).Include(u => u.Flat).ThenInclude(u => u.Block).Include(u => u.Flat).ThenInclude(u => u.User).Include(u => u.Flat).ThenInclude(u => u.UserType)

                .Select(x => new BillFlatDTO()
                {
                    Id = x.Id,
                    BillId = x.BillId,
                    FlatId = x.FlatId,
                    Description = x.Description,
                    Amount = x.Amount,
                    BillDTO = new BillDTO()
                    {
                        Id = x.Bill.Id
                                            ,
                        BillTypeId = x.Bill.BillTypeId
                                            ,
                        BillTypeName = x.Bill.BillType.Name
                                            ,
                        Description = x.Bill.Description
                                            ,
                        Mount = x.Bill.Mount
                                            ,
                        Year = x.Bill.Year
                    },
                    FlatDTO = new FlatDTO()
                    {
                        Id = x.Flat.Id,
                        BlockId = x.Flat.BlockId,
                        BlockName = x.Flat.Block.Name,
                        Description = x.Flat.Description,
                        FlatTypeId = x.Flat.FlatTypeId,
                        FlatTypeName = x.Flat.FlatType.Name,
                        Floor = x.Flat.Floor,
                        No = x.Flat.No,
                        UserId = x.Flat.UserId,
                        UserEmail = x.Flat.User.Email,
                        UserFirstName = x.Flat.User.FirstName,
                        UserLastName = x.Flat.User.LastName,
                        UserPhoneNumber = x.Flat.User.PhoneNumber,
                        UserTypeId = x.Flat.UserTypeId,
                        UserTypeName = x.Flat.UserType.Name
                    }
                }).ToList();
            return billFlats;
        }
        public ReturnObjectDTO AddBillFlat(BillFlatDTO billFlat)
        {
            try
            {
                var billFlatEntity = new BillFlat()
                {
                    BillId = billFlat.BillId,
                    FlatId = billFlat.FlatId,
                    Description = billFlat.Description,
                    Amount = billFlat.Amount,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(billFlatEntity);
                unitOfWork.Commit();

                //billFlat.Id = billFlatEntity.Id;

                var resData = GetBillFlat(billFlatEntity.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateBillFlat(int id, BillFlatDTO billFlat, string updatedBy = "Api Kullanicisi")
        {
            if (id != billFlat.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetBillFlat(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.BillId = billFlat.BillId;
            entity.FlatId = billFlat.FlatId;
            entity.Description = billFlat.Description;
            entity.Amount = billFlat.Amount;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                var resData = GetBillFlat(billFlat.Id).data;
                return new ReturnObjectDTO() { data = resData, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO DeleteBillFlat(int id, string updatedBy = "Api Kullanicisi")
        {
            var entity = repository.GetById(id);//GetBillFlat(id);
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

        public ReturnObjectDTO AddOrUpdateBillFlat(List<BillFlatAjaxDTO> billflatdtos, string updatedBy = "Api Kullanicisi")
        {
            var res = new List<BillFlatDTO>();

            var addList = new List<BillFlat>();
            var updateList = new List<BillFlat>();

            try
            {

                foreach (BillFlatAjaxDTO item in billflatdtos)
                {
                    if (item.i == 0)
                    {
                        var entity = BillFlats().Where(x => x.BillId == item.b && x.FlatId == item.f).FirstOrDefault();
                        if (entity == null)
                        {
                            entity = new BillFlat() { FlatId = item.f, BillId = item.b, Description = item.d, Amount = item.a, IsActive = true, DateCreated = DateTime.Now };
                            addList.Add(entity);
                            repository.Add(entity);
                        }
                        else
                        {
                            entity.Amount = item.a;
                            entity.Description = item.d;

                            updateList.Add(entity);
                            repository.Update(entity);
                        }
                    }
                    else
                    {
                        var entity = BillFlats().Where(x => x.Id == item.i).FirstOrDefault();
                        entity.Amount = item.a;
                        entity.Description = item.d;

                        updateList.Add(entity);
                        repository.Update(entity);


                    }

                }

                //repository.AddRange(addList);
                //repository.UpdateRange(updateList);
                unitOfWork.Commit();


                foreach (var item in addList)
                {
                    res.Add((BillFlatDTO)GetBillFlat(item.Id).data);
                }
                foreach (var item in updateList)
                {
                    res.Add((BillFlatDTO)GetBillFlat(item.Id).data);
                }

                //res.AddRange(addList.Select(x => new BillFlatDTO() { Id = x.Id, Amount = x.Amount, Description = x.Description, BillId = x.BillId, FlatId = x.FlatId }).ToList());
                //res.AddRange(updateList.Select(x => new BillFlatDTO() { Id = x.Id, Amount = x.Amount, Description = x.Description, BillId = x.BillId, FlatId = x.FlatId }).ToList());
                return new ReturnObjectDTO() { data = res, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
    }
}
