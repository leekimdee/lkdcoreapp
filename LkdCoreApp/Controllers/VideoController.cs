using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkdCoreApp.Application.Implementations;
using LkdCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LkdCoreApp.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public IActionResult Index()
        {
            var video = _videoService.GetAll();
            return View(video);
        }
    }
}