using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFlatTypeService
    {
        IQueryable<FlatType> FlatTypes();

        ReturnObjectDTO GetFlatType(int id);
        ReturnObjectDTO GetAllFlatTypes();
        ReturnObjectDTO AddFlatType(FlatTypeDTO flatType);

        ReturnObjectDTO UpdateFlatType(int id, FlatTypeDTO flatType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteFlatType(int id, string updatedBy = "Api Kullanicisi");
    }
}
