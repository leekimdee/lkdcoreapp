﻿using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace LkdCoreApp.Areas.Admin.Controllers
{
    public class ImageAlbumController : BaseController
    {
        private IImageAlbumService _imageAlbumService;

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

        [HttpPost]
        public IActionResult SaveEntity(ImageAlbumViewModel imageAlbumVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (imageAlbumVm.Id == 0)
                {
                    _imageAlbumService.Add(imageAlbumVm);
                }
                else
                {
                    _imageAlbumService.Update(imageAlbumVm);
                }
                _imageAlbumService.Save();
                return new OkObjectResult(imageAlbumVm);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _imageAlbumService.GetById(id);

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
                _imageAlbumService.Delete(id);
                _imageAlbumService.Save();

                return new OkObjectResult(id);
            }
        }

        #endregion AJAX API
    }
}