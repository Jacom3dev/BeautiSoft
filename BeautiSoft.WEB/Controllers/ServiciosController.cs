using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult ListarServicios()
        {
            return View();
        }

        public IActionResult CrearServicio()
        {
            return View();
        }
    }
}
