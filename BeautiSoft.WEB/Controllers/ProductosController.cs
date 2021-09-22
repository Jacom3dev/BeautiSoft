using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BeautiSoft.WEB.Helpers.Helper;

namespace BeautiSoft.WEB.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoServicios _productoServicios;

        public ProductosController(IProductoServicios productoServicios)
        {
            _productoServicios = productoServicios;
        }
     
        public IActionResult CrearProducto()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _productoServicios.Crear(producto);
                    var guardar = await _productoServicios.GuardarCambios();
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

            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos" });

        }

        public async Task<IActionResult> ListarProductos()
        {
            return View(await _productoServicios.ListarProductos());
        }

        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> ActualizarProducto(Guid ProductoID)
        {
            try
            {
                var producto = await _productoServicios.GetProductoID(ProductoID);
                if (producto == null)
                {
                    return Json(new { isValid = false, tipoError = "error", mensaje = "No existe el Producto" });

                }

                return View(producto);
            }
            catch (Exception)
            {
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            }
        }


    }
}
