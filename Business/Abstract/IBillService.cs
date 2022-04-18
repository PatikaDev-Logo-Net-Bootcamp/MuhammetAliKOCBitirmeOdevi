using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBillService
    {
        IQueryable<Bill> Bills();

        ReturnObjectDTO GetBill(int id);
        List<BillDTO> GetAllBills();
        ReturnObjectDTO AddBill(BillDTO flatType);

        ReturnObjectDTO UpdateBill(int id, BillDTO flatType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteBill(int id, string updatedBy = "Api Kullanicisi");
    }
}
