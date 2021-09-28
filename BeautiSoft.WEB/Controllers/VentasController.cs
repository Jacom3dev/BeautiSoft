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

            ViewBag.Documentos = new SelectList(await _ventaServicios.Documentos(), "Documento", "Nombre");
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

        [HttpGet]
        public async Task<IActionResult> Editar(Guid VentaID)
        {
            try
            {
                var venta = await _ventaServicios.GetVentaId(VentaID);
                if (venta == null)
                {
                    return Json(new { isValid = false, tipoError = "error", mensaje = "No existe registro de compra" });

                }

                ViewBag.Documentos = new SelectList(await _ventaServicios.Documentos(), "Documento", "Documento");
                ViewBag.Productos = new SelectList(await _ventaServicios.Productos(), "ProductoID", "Nombre");
                return View(venta);

            }
            catch (Exception)
            {

                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Guid VentaID, Venta venta)
        {
            if (VentaID != venta.VentaId)
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            if (ModelState.IsValid)
            {
                try
                {
                    _ventaServicios.Editar(venta);
                    var Actualizar = await _ventaServicios.GuardarCambios();
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
            ViewBag.Documentos = new SelectList(await _ventaServicios.Documentos(), "Documento", "Documento");
            ViewBag.Productos = new SelectList(await _ventaServicios.Productos(), "ProductoID", "Nombre");
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos" });
        }
        [NoDirectAccessAttribute]
        public async Task<IActionResult> Detalle(Guid VentaID)
        {
            try
            {
                var venta = await _ventaServicios.GetVentaId(VentaID);
                if (venta != null)
                {
                    return View(venta);

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
