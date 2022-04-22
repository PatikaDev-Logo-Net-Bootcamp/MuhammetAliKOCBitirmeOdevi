using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IBillService
    {
        IQueryable<Bill> Bills();
        ReturnObjectDTO GetBill(int id);
        List<BillDTO> GetAllBills();
        ReturnObjectDTO AddBill(BillDTO flatType);
        ReturnObjectDTO UpdateBill(int id, BillDTO flatType, string updatedBy = "");
        ReturnObjectDTO DeleteBill(int id, string updatedBy = "");
    }
}
