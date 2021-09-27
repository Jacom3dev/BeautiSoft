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
        public async Task<IEnumerable<Venta>> ListarVentas()
        {
            return await _context.Ventas.Include(x=>x.Producto).Include(y=>y.Cliente).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> Documentos()
        {
            return await _context.Clientes.Where(x=>x.Estado==true).ToListAsync();
        }
        public async Task<IEnumerable<Producto>> Productos()
        {
            return await _context.Productos.Where(x => x.Estado == true).ToListAsync();
        }
        public void Crear(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));
            venta.VentaId = Guid.NewGuid();
            _context.Add(venta);
        }
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
