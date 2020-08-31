using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LkdCoreApp.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}