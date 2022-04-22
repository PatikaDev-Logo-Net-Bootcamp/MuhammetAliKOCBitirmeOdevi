using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IBillTypeService
    {
        IQueryable<BillType> BillTypes();
        ReturnObjectDTO GetBillType(int id);
        List<BillTypeDTO> GetAllBillTypes();
        ReturnObjectDTO AddBillType(BillTypeDTO flatType);
        ReturnObjectDTO UpdateBillType(int id, BillTypeDTO flatType, string updatedBy = "");
        ReturnObjectDTO DeleteBillType(int id, string updatedBy = "");
    }
}
