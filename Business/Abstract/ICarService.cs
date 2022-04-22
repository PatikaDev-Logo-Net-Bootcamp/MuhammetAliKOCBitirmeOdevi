using Business.DTO;
using Domain.Entities;
using System.Linq;

namespace Business.Abstract
{
    public interface ICarService
    {
        IQueryable<Car> Cars();
        ReturnObjectDTO GetCar(int id);
        ReturnObjectDTO GetAllCars();
        ReturnObjectDTO AddCar(CarDTO car);
        ReturnObjectDTO UpdateCar(int id, CarDTO car, string updatedBy = "");
        ReturnObjectDTO DeleteCar(int id, string updatedBy = "");
    }
}
