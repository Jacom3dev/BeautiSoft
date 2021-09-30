using BeautiSoft.Servicios.Dtos;
using BeautiSoft.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuariosController(IUsuarioServicio UsuarioServicio)
        {
            _usuarioServicio = UsuarioServicio;
        }
        public async Task<IActionResult> IndexUser()
        {
            //enviamos una lista vacia
            //List<Usuario> usuarios = new();

            return View(await _usuarioServicio.GetlistUser());
        }

        public IActionResult CrearUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUser(RegistrarUserDto registrarUserDto)
        {

            if (ModelState.IsValid)
            {    //search email of user (comprovar si existe)
                var email = await _usuarioServicio.GetUserDtoforEmail(registrarUserDto.Email);
                if (email == null)
                {
                    try
                    {
                        var usuario = await _usuarioServicio.Create(registrarUserDto);
                        if (usuario == null)
                            return Json(new { isValid = false, tipoError = "error", error = "Error al crear el usuario" });

                        if (usuario.Equals("ErrorPassword"))
                            return Json(new { isValid = false, tipoError = "error", error = "Error Password" });


                        return Json(new { isValid = true, operacio = "crear" });
                    }
                    catch (Exception)
                    {

                        return Json(new { isValid = false, tipoError = "error", error = "Error al crear el registro" });
                    }
                }
            }
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos" });
        }
    }
}
