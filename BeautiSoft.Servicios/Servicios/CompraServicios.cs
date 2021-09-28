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
   public class CompraServicios:ICompraServicios
   {
        private readonly AppDbContext _context;

        public CompraServicios(AppDbContext context)
        {
            _context = context;
        }
        //tolist compras 
        public async Task<IEnumerable<Compra>> ComprasTolist()
        {
            return await _context.Compras.Include(x=>x.Producto).ToListAsync();
        }
        //this method list activate product
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos.Where(x => x.Estado == true).ToListAsync();
        }
        public async Task<Compra> GetCompraId(Guid CompraID)
        {
            return await _context.Compras.Include(x=>x.Producto).FirstOrDefaultAsync(x=>x.CompraID == CompraID);
        }

        //this method create
        public void Crear(Compra compra)
        {
            if (compra == null)

                throw new ArgumentNullException(nameof(compra));
            compra.CompraID = Guid.NewGuid();
            compra.Fecha = DateTime.Now;
            _context.Add(compra);
        }
        public void Actualizar(Compra compra)
        {
            if (compra == null)
                throw new ArgumentNullException(nameof(compra));
            _context.Update(compra);
        }
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }

}
