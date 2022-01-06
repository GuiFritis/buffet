using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Controllers
{
    public class AjudaController : Controller
    {
        public AjudaController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
