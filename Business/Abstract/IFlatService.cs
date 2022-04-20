using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFlatService
    {
        IQueryable<Flat> Flats();

        IQueryable<FlatDTO> FlatDTOs();
        IQueryable<FlatDTO> FlatDTOsByBillId(int billId);


        ReturnObjectDTO GetFlat(int id);
        List<FlatDTO> GetAllFlats();
        ReturnObjectDTO AddFlat(FlatDTO flat);

        ReturnObjectDTO UpdateFlat(int id, FlatDTO flat, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteFlat(int id, string updatedBy = "Api Kullanicisi");
    }
}
