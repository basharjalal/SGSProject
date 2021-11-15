using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SGS.WebMVC;

using Kendo.Mvc.UI;

using Microsoft.EntityFrameworkCore;
using SGS.Domain.Dto;

namespace SGS.WebMVC.Controllers
{
    public class InformationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
