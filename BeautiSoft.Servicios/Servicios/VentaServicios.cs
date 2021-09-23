using BeautiSoft.DAL;
using BeautiSoft.Models.Entidades;
using BeautiSoft.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Servicios
{
    public class VentaServicios:IVentaServicios
    {
        private readonly AppDbContext _context;

        public VentaServicios(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> Documentos()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<IEnumerable<Producto>> Productos()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
