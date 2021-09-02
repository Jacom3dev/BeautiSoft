using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListarProductos()
        {
            @ViewData["Title"] = "Productos";
            return View();
        }

        public IActionResult ListarVentas()
        {
            @ViewData["Title"] = "Ventas";
            return View();
        }

        public IActionResult ListarCompras()
        {
            @ViewData["Title"] = "Compras";
            return View();
        }


    }
}
