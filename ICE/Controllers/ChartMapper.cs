using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    public class ChartMapper : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
