using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LkdCoreApp.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API
        [HttpPost]
        public IActionResult SaveEntity(ImageViewModel imageVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (imageVm.Id == 0)
                {
                    _imageService.Add(imageVm);
                }
                else
                {
                    _imageService.Update(imageVm);
                }
                _imageService.Save();
                return new OkObjectResult(imageVm);
            }
        }

        [HttpPost]
        public IActionResult SaveMulti(List<ImageViewModel> imageListVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                foreach (var image in imageListVm)
                {
                    _imageService.Add(image);
                }
                _imageService.Save();
            }
            return new OkObjectResult(imageListVm);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _imageService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _imageService.GetById(id);

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
                _imageService.Delete(id);
                _imageService.Save();

                return new OkObjectResult(id);
            }
        }
        #endregion
    }
}