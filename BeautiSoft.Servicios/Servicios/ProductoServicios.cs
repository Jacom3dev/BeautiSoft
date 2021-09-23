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
    public class ProductoServicios:IProductoServicios
    {
        private readonly AppDbContext _context;

        public ProductoServicios(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ListarProductos()
        {
            return await _context.Productos.OrderBy(x => x.ProductoID).ToListAsync();
        }
            //Crear Producto
        public void Crear(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));
            producto.ProductoID = Guid.NewGuid();
            producto.Estado = true;
            producto.Imagen = "shampo.png";
            _context.Add(producto);
        }
        //Obtener los id para validar si existe el producto
        public async Task<Producto> GetProductoID(Guid ProductoID)
        { 
            return await _context.Productos.FirstOrDefaultAsync(x => x.ProductoID == ProductoID);
        }

        public void ActualizarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));
            _context.Update(producto);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }
       
    }
}
