using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class ComprasController : Controller
    {
        public IActionResult ListarCompras()
        {
            @ViewData["Title"] = "Compras";
            return View();
        }
        public IActionResult CrearCompra()
        {
            @ViewData["Title"] = "Compras";
            return View();
        }
    }
}
