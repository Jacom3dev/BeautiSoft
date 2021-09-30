using BeautiSoft.Servicios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDto> GetUserDtoforEmail(String email);
        Task<IEnumerable<UsuarioDto>> GetlistUser();
        Task<String> Create(RegistrarUserDto registrarUserDto);
    }
}
