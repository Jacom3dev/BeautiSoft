using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Dtos;
using BeautiSoft.Servicios.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly UserManager<Usuario> _usermanager;

        public UsuarioServicio(UserManager<Usuario> usermanager)
        {
            _usermanager = usermanager;
        }

        //tolist users
        public async Task<IEnumerable<UsuarioDto>> GetlistUser()
        {
            List<UsuarioDto> listarUsuariosDtos = new();
            var usuarios = await _usermanager.Users.ToListAsync();
            usuarios.ForEach(usuario =>//convert to userDto
            {
                UsuarioDto usuarioDto = new()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Estado = usuario.Estado

                };
                listarUsuariosDtos.Add(usuarioDto);
            });
            return listarUsuariosDtos;

        }

        //create user
        public async Task<String> Create(RegistrarUserDto registrarUserDto)
        {
            if (registrarUserDto == null)
                throw new ArgumentNullException(nameof(registrarUserDto));
            Usuario usuario = new()
            {
                UserName = registrarUserDto.Email,
                Email = registrarUserDto.Email,
                Estado = true,
            };
            var result = await _usermanager.CreateAsync(usuario, registrarUserDto.Password);
            if (result.Errors.Any())
                return "ErrorPassword";

            if (result.Succeeded)
                return usuario.Id;
            return null;
        }

        //comvierte todo en dto y lo devuelve

        public async Task<UsuarioDto> GetUserDtoforEmail(string email)
        {
            if (email == null)

                throw new ArgumentNullException(nameof(email));
            var usuario = await _usermanager.FindByEmailAsync(email);
            if (usuario != null)
            {
                UsuarioDto usuarioDto = new()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Estado = usuario.Estado
                };
                return usuarioDto;
            }

            return null;
        }
    }
}
