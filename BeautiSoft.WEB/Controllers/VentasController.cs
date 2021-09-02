using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult ListarVentas()
        {
            @ViewData["Title"] = "Ventas";
            return View();
        }
    }
}
