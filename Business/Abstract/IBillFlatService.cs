using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBillFlatService
    {
        IQueryable<BillFlat> BillFlats();

        ReturnObjectDTO GetBillFlat(int id);
        List<BillFlatDTO> GetAllBillFlats();
        IQueryable<BillFlatDTO> GetAllBillFlatsAsQueryable(int yearid, int mountid, int billtypeid, int isPaidid);
        ReturnObjectDTO AddBillFlat(BillFlatDTO flatType);

        ReturnObjectDTO UpdateBillFlat(int id, BillFlatDTO flatType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO Pay(int id, string userid);

        ReturnObjectDTO DeleteBillFlat(int id, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO AddOrUpdateBillFlat(List<BillFlatAjaxDTO> billflatdtos, string updatedBy = "Api Kullanicisi");

        List<BillFlatDTO> GetUserBillFlats(int yearid, int mountid, string userid, int isPaidid);
    }
}
