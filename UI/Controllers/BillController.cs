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

        public BillController(ILogger<BillController> logger, IBillService billService, IBillFlatService billFlatService, IBillTypeService billTypeService)
        {
            _logger = logger;
            _billService = billService;
            _billFlatService = billFlatService;
            _billTypeService = billTypeService;
        }

        public async Task<IActionResult> Index(string sortOrder,
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

            int pageSize = 10;

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




        public ActionResult BillFlat()
        {
            return null;
        }



    }
}
