using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders home page
        /// </summary>
        /// <returns>view</returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}
