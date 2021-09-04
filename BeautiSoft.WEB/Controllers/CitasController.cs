using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult ListarCitas()
        {
            return View();
        }

        public IActionResult CrearCita()
        {
            return View();
        }
    }
}
