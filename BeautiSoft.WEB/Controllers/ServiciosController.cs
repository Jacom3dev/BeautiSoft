using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Interfaces;
using BeautiSoft.WEB.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BeautiSoft.WEB.Helpers.Helper;

namespace BeautiSoft.WEB.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServicioServicios _servicioServicios;

        public ServiciosController(IServicioServicios ServicioServicios)
        {
            _servicioServicios = ServicioServicios;
        }
        public async Task<IActionResult> ListarServicios()
        {
            return View(await _servicioServicios.ListarServicio());
        }
        public IActionResult CrearServicio()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _servicioServicios.Crear(servicio);
                    var save = await _servicioServicios.GuardarCambios();
                    if (save)
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

        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> ActualizarServicio(Guid ServicioID)
        {
            try
            {
                var servicio = await _servicioServicios.GetServicioId(ServicioID);
                if (servicio == null)
                {
                    return Json(new { isValid = false, tipoError = "error", mensaje = "No existe el servicio" });

                }

                return View(servicio);
            }
            catch (Exception)
            {
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> ActualizarServicio(Guid ServicioID, Servicio servicio)   
        {
            if (ServicioID != servicio.ServicioID)
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            if (ModelState.IsValid)
            {
                try
                {

                    _servicioServicios.ActualizarServicio(servicio);
                    var editar = await _servicioServicios.GuardarCambios();
                    if (editar)
                        return Json(new { isValid = true, operacion = "editar" });
                    else
                        return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
                }
                catch (Exception)
                {

                    return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
                }
            }

            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos", html = Helper.RenderRazorViewToString(this, "Editar", servicio) });
        }
        [NoDirectAccessAttribute]
        public async Task<IActionResult> CambiarEstado(Guid ServicioID)
        {
            try
            {
                var servicio = await _servicioServicios.GetServicioId(ServicioID);
                if (servicio != null)
                {
                    servicio.Estado = !servicio.Estado;

                    _servicioServicios.ActualizarServicio(servicio);

                    var guardar = await _servicioServicios.GuardarCambios();
                    if (guardar)
                        return Json(new { isValid = true });

                }
                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });

            }
            catch (Exception)
            {

                return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
            }
        }

        [NoDirectAccessAttribute]
        public async Task<IActionResult> DetalleServicio(Guid ServicioID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var servicio = await _servicioServicios.GetServicioId(ServicioID);

                    if (servicio != null)
                    {
                        return View(servicio);

                    }
                    return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });

                }
                catch (Exception)
                {

                    return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
                }

            }
            return Json(new { isValid = false, tipoError = "error", mensaje = "Error interno" });
        }


    }
}

