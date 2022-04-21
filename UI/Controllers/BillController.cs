using Business.Abstract;
using Business.DTO;
using Business.Statics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class BillController : Controller
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;
        private readonly IBillFlatService _billFlatService;
        private readonly IBillTypeService _billTypeService;
        private readonly IBlockService _blockService;
        private readonly IFlatService _flatService;
        public BillController(ILogger<BillController> logger, IBillService billService, IBillFlatService billFlatService, IBillTypeService billTypeService, IBlockService blockService, IFlatService flatService)
        {
            _logger = logger;
            _billService = billService;
            _billFlatService = billFlatService;
            _billTypeService = billTypeService;
            _blockService = blockService;
            _flatService = flatService;
        }

        public async Task<IActionResult> Index( string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewBag.Years = Year.Years;
            ViewBag.Mounts = Mount.Mounts;
            ViewBag.BillTypes  = _billTypeService.GetAllBillTypes();

            var bills = _billService.Bills();

            ViewData["YearSortParm"] = String.IsNullOrEmpty(sortOrder) ? "year_desc" : "";
            ViewData["MountSortParm"] = sortOrder == "mount" ? "mount_desc" : "mount";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                bills = bills.Where(s => s.Year.ToString().Contains(searchString)
                                       || s.Mount.ToString().Contains(searchString)
                                       || s.BillType.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "year_desc":
                    bills = bills.OrderByDescending(s => s.Year);
                    break;
                case "mount":
                    bills = bills.OrderBy(s => s.Mount);
                    break;
                case "mount_desc":
                    bills = bills.OrderByDescending(s => s.Mount);
                    break;
                default:
                    bills = bills.OrderBy(s => s.Year);
                    break;
            }

            var billDTOs = bills.Include(x => x.BillType).Select(x => new BillDTO()
            {
                Id = x.Id,
                Year = x.Year,
                Mount = x.Mount,
                Description = x.Description,
                BillTypeId = x.BillTypeId,
                BillTypeName = x.BillType.Name

            });

            int pageSize = 25;

            //BillListDTO model = new BillListDTO();
            //model.Bills = billDTOs.ToList();
            //return View(await PaginatedList<BillListDTO>.CreateAsync(billDTOs.AsQueryable().AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(await PaginatedList<BillDTO>.CreateAsync(billDTOs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        [HttpPost]
        public JsonResult AddBill(BillDTO bill)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            //BillDTO bill = billList.Bill;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _billService.AddBill(bill);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetBill(int id)
        {
            var res = _billService.GetBill(id);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateBill(BillDTO bill)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            //BillDTO bill = billList.Bill;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _billService.UpdateBill(bill.Id, bill);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteBill(int id)
        {
            var res = _billService.DeleteBill(id);

            return new JsonResult(res);
        }




        public async Task<IActionResult> BillFlatList(int billId,
                                                string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewBag.BillId = billId;
            var bill = _billService.GetBill(billId).data as BillDTO;
            ViewBag.BillName = bill.Year + " " + bill.Mount + " " + bill.BillTypeName + " Faturası";


            var flats = _flatService.FlatDTOsByBillId(billId);

            ViewData["BlockSortParm"] = String.IsNullOrEmpty(sortOrder) ? "block_desc" : "";
            //ViewData["MountSortParm"] = sortOrder == "mount" ? "mount_desc" : "mount";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                flats = flats.Where(s => s.BlockName.Contains(searchString)
                                       || s.FlatTypeName.Contains(searchString)
                                       || s.No.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "block_desc":
                    flats = flats.OrderByDescending(s => s.BlockName);
                    break;
                //case "mount":
                //    billFlats = billFlats.OrderBy(s => s.Mount);
                //    break;
                //case "mount_desc":
                //    billFlats = billFlats.OrderByDescending(s => s.Mount);
                //    break;
                default:
                    flats = flats.OrderBy(s => s.BlockName);
                    break;
            }

            //flats = flats.ToList();
            //var billFlatDTOs = billFlats.Include(x => x.BillFlatType).Select(x => new BillFlatDTO()
            //{
            //    Id = x.Id,
            //    Year = x.Year,
            //    Mount = x.Mount,
            //    Description = x.Description,
            //    BillFlatTypeId = x.BillFlatTypeId,
            //    BillFlatTypeName = x.BillFlatType.Name

            //});

            int pageSize = 25;

            //BillFlatListDTO model = new BillFlatListDTO();
            //model.BillFlats = billFlatDTOs.ToList();
            //return View(await PaginatedList<BillFlatListDTO>.CreateAsync(billFlatDTOs.AsQueryable().AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(await PaginatedList<FlatDTO>.CreateAsync(flats.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        [HttpPost]
        public JsonResult AddBillFlat(BillFlatDTO BillFlatDTO)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            //BillFlatDTO billFlat = billFlatList.BillFlat;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _billFlatService.AddBillFlat(BillFlatDTO);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetBillFlat(int id)
        {
            var res = _billFlatService.GetBillFlat(id);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateBillFlat(BillFlatDTO BillFlatDTO)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            //BillFlatDTO billFlat = billFlatList.BillFlat;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _billFlatService.UpdateBillFlat(BillFlatDTO.Id, BillFlatDTO);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteBillFlat(int id)
        {
            var res = _billFlatService.DeleteBillFlat(id);

            return new JsonResult(res);
        }


        [HttpPost]
        public JsonResult AddUpdateCheckedBillFlat(List<BillFlatAjaxDTO> billflatdtos)
        {

            var res = _billFlatService.AddOrUpdateBillFlat(billflatdtos);

            return new JsonResult(res);
        }




        public async Task<IActionResult> BillList(int Yearid, int Mountid, int BillTypeid, int isPaidid,
                                                string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {

            ViewBag.Years = Year.Years;
            ViewBag.Mounts = Mount.Mounts;
            ViewBag.BillTypes = _billTypeService.GetAllBillTypes();
            ViewBag.isPaid = new List<KodDTO>() { new KodDTO(-1, "Seçiniz"), new KodDTO(0, "ÖDENMEDİ"), new KodDTO(1, "Ödendi") };

            ViewData["CurrentFilterYearid"] = Yearid;
            ViewData["CurrentFilterMountid"] = Mountid;
            ViewData["CurrentFilterBillTypeid"] = BillTypeid;
            ViewData["CurrentFilterisPaidid"] = isPaidid;

            //ViewBag.BillId = billId;
            //var bill = _billService.GetBill(billId).data as BillDTO;
            //ViewBag.BillName = bill.Year + " " + bill.Mount + " " + bill.BillTypeName + " Faturası";


            var flats = _billFlatService.GetAllBillFlatsAsQueryable(Yearid, Mountid, BillTypeid, isPaidid);

            ViewData["BlockSortParm"] = String.IsNullOrEmpty(sortOrder) ? "block_desc" : "";
            //ViewData["MountSortParm"] = sortOrder == "mount" ? "mount_desc" : "mount";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                flats = flats.Where(s => s.FlatDTO.BlockName.Contains(searchString)
                                       || s.FlatDTO.FlatTypeName.Contains(searchString)
                                       || s.FlatDTO.No.Contains(searchString)
                                       || s.Description.Contains(searchString)) ;
            }


            switch (sortOrder)
            {
                case "block_desc":
                    flats = flats.OrderByDescending(s => s.FlatDTO.BlockName);
                    break;
 
                default:
                    flats = flats.OrderBy(s => s.FlatDTO.BlockName);
                    break;
            }

 

            int pageSize = 25;

 
            return View(await PaginatedList<BillFlatDTO>.CreateAsync(flats.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        public async Task<IActionResult> BillSummory(int Yearid, int Mountid, int BillTypeid)
        {

            ViewBag.Years = Year.Years;
            ViewBag.Mounts = Mount.Mounts;
            ViewBag.BillTypes = _billTypeService.GetAllBillTypes();
             

            ViewData["CurrentFilterYearid"] = Yearid;
            ViewData["CurrentFilterMountid"] = Mountid;
            ViewData["CurrentFilterBillTypeid"] = BillTypeid;



            var model = new List<SummoryDTO>();

            var list = _billFlatService.GetAllBillFlatsAsQueryable(Yearid, Mountid, BillTypeid, -1).ToList();
                
               var paidBillValue = list.Where(x=>x.IsPaid).Sum(x=>x.Amount);
            model.Add(new SummoryDTO("Ödenen", paidBillValue));

            var unPaidBillValue = list.Where(x => !x.IsPaid).Sum(x => x.Amount);
            model.Add(new SummoryDTO("Ödenmemiş", unPaidBillValue));


            model.Add(new SummoryDTO("TOPLAM", paidBillValue+ unPaidBillValue));



      


            return View(model);
        }



    }



 








}
