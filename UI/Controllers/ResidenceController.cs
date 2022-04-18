using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ResidenceController : Controller
    {
        private readonly ILogger<ResidenceController> _logger;
        private readonly IBlockService _blockService;
        private readonly IFlatService _flatService;
        private readonly IFlatTypeService _flatTypeService;
        private readonly IUserTypeService _UserTypeService;
        private readonly UserManager<User> _userManager;

        public ResidenceController(ILogger<ResidenceController> logger, IBlockService blockService, IFlatService flatService, IFlatTypeService flatTypeService, IUserTypeService userTypeService, UserManager<User> userManager)
        {
            _logger = logger;
            _blockService = blockService;
            _flatService = flatService;
           _flatTypeService = flatTypeService;
            _UserTypeService = userTypeService;
            _userManager = userManager;
        }

        public IActionResult BlockList()
        {
            var model = new BlockListDTO();
            var blocks = _blockService.GetAllBlocks();
                
            model.Blocks = blocks;
            return View(model);
        }


        [HttpPost]
        public JsonResult AddBlock(BlockListDTO blockList)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            BlockDTO block = blockList.Block;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _blockService.AddBlock(block);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetBlock(int id)
        {
            var res = _blockService.GetBlock(id);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateBlock(BlockListDTO blockList)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            BlockDTO block = blockList.Block;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _blockService.UpdateBlock(block.Id, block);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteBlock(int id)
        {
            var res = _blockService.DeleteBlock(id);

            return new JsonResult(res);
        }




        public IActionResult FlatList()
        {
            var model = new FlatListDTO();
            var flats = _flatService.GetAllFlats();

            var users = _userManager.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,               
                PhoneNumber = x.PhoneNumber   ,
                Description = x.FirstName + " " + x.LastName + "("+x.PhoneNumber+")",
            }).ToList();
            ViewBag.Users = users;
            var blocks = _blockService.GetAllBlocks();
            ViewBag.Blocks = blocks;
            var flatTypes = _flatTypeService.GetAllFlatTypes();
            ViewBag.FlatTypes = flatTypes;
            var userTypes = _UserTypeService.GetAllUserTypes();
            ViewBag.UserTypes = userTypes;

            model.Flats = flats;
            return View(model);
        }


        [HttpPost]
        public JsonResult AddFlat(FlatListDTO flatList)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            FlatDTO flat = flatList.Flat;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _flatService.AddFlat(flat);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetFlat(int id)
        {
            var res = _flatService.GetFlat(id);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateFlat(FlatListDTO flatList)
        {
            /* var errors = ModelState
     .Where(x => x.Value.Errors.Count > 0)
     .Select(x => new { x.Key, x.Value.Errors })
     .ToArray();
            */

            FlatDTO flat = flatList.Flat;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _flatService.UpdateFlat(flat.Id, flat);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteFlat(int id)
        {
            var res = _flatService.DeleteFlat(id);

            return new JsonResult(res);
        }
    }
}
