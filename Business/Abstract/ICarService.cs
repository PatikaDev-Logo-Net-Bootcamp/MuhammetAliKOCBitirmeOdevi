using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IQueryable<Car> Cars();

        ReturnObjectDTO GetCar(int id);
        ReturnObjectDTO GetAllCars();
        ReturnObjectDTO AddCar(CarDTO car);

        ReturnObjectDTO UpdateCar(int id, CarDTO car, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteCar(int id, string updatedBy = "Api Kullanicisi");
    }
}
