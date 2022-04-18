﻿using Business.DTO;
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
        ReturnObjectDTO AddBillFlat(BillFlatDTO flatType);

        ReturnObjectDTO UpdateBillFlat(int id, BillFlatDTO flatType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteBillFlat(int id, string updatedBy = "Api Kullanicisi");
    }
}
