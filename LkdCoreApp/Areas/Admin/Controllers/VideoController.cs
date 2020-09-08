using LkdCoreApp.Application.Implementations;
using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace LkdCoreApp.Areas.Admin.Controllers
{
    public class VideoController : BaseController
    {
        private IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _videoService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _videoService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(VideoViewModel videoVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (videoVm.Id == 0)
                {
                    _videoService.Add(videoVm);
                }
                else
                {
                    _videoService.Update(videoVm);
                }
                _videoService.Save();
                return new OkObjectResult(videoVm);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _videoService.GetById(id);

            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _videoService.Delete(id);
                _videoService.Save();

                return new OkObjectResult(id);
            }
        }

        #endregion AJAX API
    }
}