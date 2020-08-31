using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkdCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LkdCoreApp.Areas.Admin.Controllers
{
    public class ImageAlbumController : BaseController
    {
        IImageAlbumService _imageAlbumService;

        public ImageAlbumController(IImageAlbumService imageAlbumService)
        {
            _imageAlbumService = imageAlbumService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _imageAlbumService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _imageAlbumService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }
        #endregion
    }
}