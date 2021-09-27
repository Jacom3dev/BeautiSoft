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
    public class ComprasController : Controller
    {
        private readonly ICompraServicios _compraServicios;
        private readonly IProductoServicios _productoServicios;

        public ComprasController(ICompraServicios CompraServicios, IProductoServicios productoServicios)
        {
            _compraServicios = CompraServicios;
            _productoServicios = productoServicios;
        }
        public async Task<IActionResult> ListarCompras()
        {
            ViewBag.Title = "Gestion de compras";
            return View(await _compraServicios.ComprasTolist());
        }
        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> CrearCompra()
        {
            @ViewData["Title"] = "Crear Compra";
            ViewBag.Productos = new SelectList(await _compraServicios.GetProductos(), "ProductoID", "Nombre");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CrearCompra(Compra compra)
        {
            if (ModelState.IsValid)
            {
                try
                {    
                    _compraServicios.Crear(compra);
                    var guardar = await _compraServicios.GuardarCambios();
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

            ViewBag.Productos = new SelectList(await _compraServicios.GetProductos(), "ProductoID", "Nombre");
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos" });
        }
    }
}