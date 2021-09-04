using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Login
    {
        [Key]
        public string UsuarioID { get; set; }
        public string NombreUsario { get; set; }
        public string Pass { get; set; }
    }
}
