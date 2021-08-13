using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace phishing.Controllers
{
    public class ResultadoController : Controller
    {
        public IActionResult Resultado()
        {
            return View();
        }
    }
}