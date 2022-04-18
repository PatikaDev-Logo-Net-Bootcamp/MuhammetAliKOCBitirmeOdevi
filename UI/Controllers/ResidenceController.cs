using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ResidenceController : Controller
    {
        private readonly ILogger<ResidenceController> _logger;
        private readonly IBlockService _blockService;

        public ResidenceController(ILogger<ResidenceController> logger, IBlockService blockService)
        {
            _logger = logger;
            _blockService = blockService;
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
            return View();
        }
    }
}
