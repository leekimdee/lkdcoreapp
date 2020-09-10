using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkdCoreApp.Application.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace LkdCoreApp.Controllers
{
    public class TestController : Controller
    {
        private TestImageService _imageService;
        private TestImageAlbumService _imageAlbumService;

        public TestController()
        {
            _imageService = new TestImageService();
            _imageAlbumService = new TestImageAlbumService();
        }

        public IActionResult Index()
        {
            ViewBag.ImageAlbums = _imageAlbumService.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult GetImagesByAlbum(int albumId)
        {
            var images = _imageService.GetImagesByAlbumId(albumId);

            return new OkObjectResult(images);
        }
    }
}