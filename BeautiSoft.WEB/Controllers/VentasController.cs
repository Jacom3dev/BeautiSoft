using BeautiSoft.Models.Entidades;
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
        public async Task<IActionResult> ListarVentas()
        {
            @ViewData["Title"] = "Ventas";
            return View(await _ventaServicios.ListarVentas());
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
        [HttpPost]
        public async Task<IActionResult> CrearVenta(Venta venta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ventaServicios.Crear(venta);
                    var guardar = await _ventaServicios.GuardarCambios();
                    if (guardar)
                    {
                        return Json(new { isValid = true, operacion = "crear" });
                    }
                }
                catch (Exception)
                {

                    return Json(new { isValid = false, tipoError = "error", error = "Error al crear el registro" });

                }

            }

            ViewBag.Documentos = new SelectList(await _ventaServicios.Documentos(), "Documento", "Documento");
            ViewBag.Productos = new SelectList(await _ventaServicios.Productos(), "ProductoID", "Nombre");
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos" });
        }


    }
}
