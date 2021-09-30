using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Dtos
{
    public class RecuperarPasswordDto
    {
        [Required(ErrorMessage = "correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo es invalido")]
        public string Email { get; set; }
    }
}
