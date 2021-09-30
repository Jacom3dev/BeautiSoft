using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BeautiSoft.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public LoginController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginIndex(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RecordarMe, false);
                if (result.Succeeded)
                    return RedirectToAction("IndexUser", "Usuarios");
                return Json(new { isValid = false, tipoError = "error", error = "El usuario no existe" });
            }
            return View();
        }

         public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginIndex", "Login");
        }

        public IActionResult OlvidePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> OlvidePassword(RecuperarPasswordDto recuperarPasswordDto)
        {
            if (ModelState.IsValid)
            {
                //buscamos si el email existe
                var usuario = await _userManager.FindByEmailAsync(recuperarPasswordDto.Email);
                if (usuario != null)
                {
                    //generamos un token
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                    //creamos un link para resetear el password
                    var passwordresetLink = Url.Action("ReseteoPassword", "Login",
                        new { email = recuperarPasswordDto.Email, token = token }, Request.Scheme);

                    //Metodo tradicional de enviar correos por smtp
                    MailMessage mensaje = new();
                    mensaje.To.Add(recuperarPasswordDto.Email); //destinatario
                    mensaje.Subject = "recuperar password Beautysoft  ";
                    mensaje.Body = passwordresetLink;
                    mensaje.IsBodyHtml = false;

                    mensaje.From = new MailAddress("mvasquez372@misena.edu.co", "Beautysoft");
                    SmtpClient smtpClient = new("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("mvasquez372@misena.edu.co", "todosmienten1818");
                    smtpClient.Send(mensaje);

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReseteoPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Error en Token");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReseteoPassword(ReseteoPasswordDto reseteoPasswordDto)
        {
            if (ModelState.IsValid)
            {

                var usuario = await _userManager.FindByEmailAsync(reseteoPasswordDto.Email);
                if (usuario != null)
                {
                    var result = await _userManager.ResetPasswordAsync(usuario, reseteoPasswordDto.Token, reseteoPasswordDto.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("LoginIndex", "Login");

                    }
                }
            }
            return View();
        }
    }
}
