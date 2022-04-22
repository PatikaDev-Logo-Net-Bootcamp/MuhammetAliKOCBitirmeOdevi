using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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
        ReturnObjectDTO UpdateFlat(int id, FlatDTO flat, string updatedBy = "");
        ReturnObjectDTO DeleteFlat(int id, string updatedBy = "");
    }
}
