using Business.Abstract;
using Business.Statics;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Controllers
{
    [Authorize]
    public class ResidentUserController : Controller
    {
        private readonly ILogger<ResidentUserController> _logger;
        private readonly IBillService _billService;
        private readonly IBillFlatService _billFlatService;
        private readonly IBillTypeService _billTypeService;
        private readonly IBlockService _blockService;
        private readonly IFlatService _flatService;
        private readonly UserManager<User> _userManager;

        public ResidentUserController(ILogger<ResidentUserController> logger, IBillService billService, IBillFlatService billFlatService, IBillTypeService billTypeService, IBlockService blockService, IFlatService flatService, UserManager<User> userManager)
        {
            _logger = logger;
            _billService = billService;
            _billFlatService = billFlatService;
            _billTypeService = billTypeService;
            _blockService = blockService;
            _flatService = flatService;
            _userManager = userManager;
        }



        public  IActionResult BillListUnPaid(int Yearid = -1, int Mountid = -1)
        {

            ViewBag.Years = Year.Years;
            ViewBag.Mounts = Mount.Mounts;
             

            ViewData["CurrentFilterYearid"] = Yearid;
            ViewData["CurrentFilterMountid"] = Mountid;
 

 
            var currentUser = _userManager.GetUserAsync(User).Result;
            var billflats = _billFlatService.GetUserBillFlats(Yearid, Mountid, currentUser.Id, 0);      


            return View(billflats);
        }


        public IActionResult BillListPaid(int Yearid = -1, int Mountid = -1)
        {

            ViewBag.Years = Year.Years;
            ViewBag.Mounts = Mount.Mounts;


            ViewData["CurrentFilterYearid"] = Yearid;
            ViewData["CurrentFilterMountid"] = Mountid;



            var currentUser = _userManager.GetUserAsync(User).Result;
            var billflats = _billFlatService.GetUserBillFlats(Yearid, Mountid, currentUser.Id, 1);


            return View(billflats);
        }

    }
}
