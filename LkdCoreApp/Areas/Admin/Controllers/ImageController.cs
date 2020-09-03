using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkdCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        #endregion
    }
}