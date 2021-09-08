using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class ServiciosRealizadosController : Controller
    {
        public IActionResult ListarServiciosRealizados()
        {
            return View();
        }
        public IActionResult CrearServicioRealizado()
        {
            return View();
        }
    }
}
