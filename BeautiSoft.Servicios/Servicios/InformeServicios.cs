using BeautiSoft.DAL;
using BeautiSoft.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Servicios
{
    public class InformeServicios
    {
        private readonly AppDbContext _context;

        public InformeServicios(AppDbContext context)
        {
            _context = context;
        }
        
    }
}
