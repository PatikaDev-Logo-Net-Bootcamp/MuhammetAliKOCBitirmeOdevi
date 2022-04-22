using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IBillFlatService
    {
        IQueryable<BillFlat> BillFlats();
        ReturnObjectDTO GetBillFlat(int id);
        List<BillFlatDTO> GetAllBillFlats();
        IQueryable<BillFlatDTO> GetAllBillFlatsAsQueryable(int yearid, int mountid, int billtypeid, int isPaidid);
        ReturnObjectDTO AddBillFlat(BillFlatDTO flatType);
        ReturnObjectDTO UpdateBillFlat(int id, BillFlatDTO flatType, string updatedBy = "");
        ReturnObjectDTO Pay(int id, string userid);
        ReturnObjectDTO DeleteBillFlat(int id, string updatedBy = "");
        ReturnObjectDTO AddOrUpdateBillFlat(List<BillFlatAjaxDTO> billflatdtos, string updatedBy = "");
        List<BillFlatDTO> GetUserBillFlats(int yearid, int mountid, string userid, int isPaidid);
    }
}
