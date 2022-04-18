using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBillTypeService
    {
        IQueryable<BillType> BillTypes();

        ReturnObjectDTO GetBillType(int id);
        List<BillTypeDTO> GetAllBillTypes();
        ReturnObjectDTO AddBillType(BillTypeDTO flatType);

        ReturnObjectDTO UpdateBillType(int id, BillTypeDTO flatType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteBillType(int id, string updatedBy = "Api Kullanicisi");
    }
}
