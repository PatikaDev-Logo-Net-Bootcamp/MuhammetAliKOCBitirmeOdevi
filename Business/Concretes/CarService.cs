using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using System;
using System.Linq;

namespace Business.Concretes
{
    public class CarService:ICarService
    {
        private readonly IRepository<Car> repository;
        private readonly IUnitOfWork unitOfWork;
        public CarService(IRepository<Car> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<Car> Cars()
        {
            return repository.GetAll();
        }
        public ReturnObjectDTO GetCar(int id)
        {
            var car =  Cars().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = car, successMessage = "İşlem Başarılı" };
        }
        public ReturnObjectDTO GetAllCars()
        {
            var cars =  repository.GetAll().ToList();
            return new ReturnObjectDTO() { data = cars };
        }
        public ReturnObjectDTO AddCar(CarDTO car)
        {
            try
            {
                var carEntity = new Car()
                {
                    UserId = car.UserId,
                    Aciklama = car.Aciklama,
                    Plaka = car.Plaka,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(carEntity);
                unitOfWork.Commit();

                car.Id = carEntity.Id;
                return new ReturnObjectDTO() { data = car, successMessage="İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess= false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO UpdateCar(int id, CarDTO car, string updatedBy = "")
        {
            if (id != car.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetCar(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.Aciklama = car.Aciklama;
            entity.Plaka = car.Plaka;
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = car, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO DeleteCar(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);//GetCar(id);
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
