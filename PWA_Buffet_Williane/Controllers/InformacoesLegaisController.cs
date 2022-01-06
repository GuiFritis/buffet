using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Controllers
{
    public class InformacoesLegaisController : Controller
    {
        public InformacoesLegaisController()
        {
        }

        public IActionResult Termos()
        {
            return View();
        }

        public IActionResult Privacidade()
        {
            return View();
        }
    }
}
