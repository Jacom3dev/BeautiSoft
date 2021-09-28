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
        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> ActualizarCompra(Guid CompraID)
        {
            try
            {
                var compra = await _compraServicios.GetCompraId(CompraID);
                if (compra == null)
                {
                    return Json(new { isValid = false, tipoError = "error", mensaje = "No existe registro de compra" });

                }

                ViewBag.Productos = new SelectList(await _compraServicios.GetProductos(), "ProductoID", "Nombre");
                return View(compra);

            }
            catch (Exception)
            {

                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCompra(Guid CompraID, Compra compra)
        {
            if (CompraID != compra.CompraID)
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            if (ModelState.IsValid)
            {
                try
                {
                    _compraServicios.Actualizar(compra);
                    var Actualizar = await _compraServicios.GuardarCambios();
                    if (Actualizar)
                        return Json(new { isValid = true, operacion = "editar" });
                    else
                        return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
                }
                catch (Exception)
                {

                    return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
                }

            }
            ViewBag.Productos = new SelectList(await _compraServicios.GetProductos(), "ProductoID", "Nombre");
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos"});
        }


        [NoDirectAccessAttribute]
        public async Task<IActionResult> DetalleCompra(Guid CompraID)
        {
            try
            {
                var compra = await _compraServicios.GetCompraId(CompraID);
                if (compra != null)
                {
                    return View(compra);

                }
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error Interno" });
            }
            catch (Exception)
            {

                return Json(new { isValid = false, tipoError = "Error", mensaje = "Error interno" });
            }
        }
    }
}