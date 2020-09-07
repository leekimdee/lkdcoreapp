using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LkdCoreApp.Controllers
{
    public class ImageController : Controller
    {
        private IImageService _imageService;
        private IImageAlbumService _imageAlbumService;

        public ImageController(IImageService imageService, IImageAlbumService imageAlbumService)
        {
            _imageService = imageService;
            _imageAlbumService = imageAlbumService;
        }

        public IActionResult Index()
        {
            ViewBag.ImageAlbums = _imageAlbumService.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult GetImagesByAlbum(int albumId)
        {
            //var imageAlbum = _imageAlbumService.GetByIdWithIncludeObject(albumId);
            var images = _imageService.GetImagesByAlbumId(albumId);

            return new OkObjectResult(images);
        }
    }
}