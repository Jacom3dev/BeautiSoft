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

        public IActionResult CrearProducto()
        {
            @ViewData["Title"] = "Crear Producto";
            return View();
        }

    }
}
