using BeautiSoft.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BeautiSoft.WEB.Helpers.Helper;

namespace BeautiSoft.WEB.Controllers
{
    public class VentasController : Controller
    {
        private readonly IVentaServicios _ventaServicios;

        public VentasController(IVentaServicios ventaServicios)
        {
            _ventaServicios = ventaServicios;
        }
        public IActionResult ListarVentas()
        {
            @ViewData["Title"] = "Ventas";
            return View();
        }
       
        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> CrearVenta()
        {
            @ViewData["Title"] = "Crear Cliente";

            ViewBag.Documentos = new SelectList(await _ventaServicios.Documentos(), "Documento", "Documento");
            ViewBag.Productos = new SelectList(await _ventaServicios.Productos(), "ProductoID", "Nombre");
            return View();
        }


    }
}
