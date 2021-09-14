﻿using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Interfaces;
using BeautiSoft.WEB.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BeautiSoft.WEB.Helpers.Helper;

namespace BeautiSoft.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteServicios _clienteServicios;

        public ClientesController(IClienteServicios clienteServicios)
        {
            _clienteServicios = clienteServicios;
        }
        public IActionResult ListarClientes()
        {
            @ViewData["Title"] = "Clientes";
            return View();
        }


        [NoDirectAccessAttribute]
        [HttpGet]
        public async Task<IActionResult> CrearCliente()
        {
            @ViewData["Title"] = "Crear Cliente";

            ViewBag.TiposDocumento = new SelectList(await _clienteServicios.TiposDocumento(), "TipoDocumentoId", "Nombre");
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> CrearCLiente(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _clienteServicios.Crear(cliente);
                    var guardar = await _clienteServicios.GuardarCambios();
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
            ViewBag.TiposDocumento = new SelectList(await _clienteServicios.TiposDocumento(), "TipoDocumentoId", "Nombre");
            //return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos", html = Helper.RenderRazorViewToString(this, "Crear", cliente) });
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos"});

        }
    }
}
