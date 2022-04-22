using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IFlatTypeService
    {
        IQueryable<FlatType> FlatTypes();
        ReturnObjectDTO GetFlatType(int id);
        List<FlatTypeDTO> GetAllFlatTypes();
        ReturnObjectDTO AddFlatType(FlatTypeDTO flatType);
        ReturnObjectDTO UpdateFlatType(int id, FlatTypeDTO flatType, string updatedBy = "");
        ReturnObjectDTO DeleteFlatType(int id, string updatedBy = "");
    }
}
