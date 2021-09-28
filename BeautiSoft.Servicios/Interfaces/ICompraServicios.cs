using BeautiSoft.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
    public interface ICompraServicios
    {
        Task<IEnumerable<Compra>> ComprasTolist();
        Task<IEnumerable<Producto>> GetProductos();
        void Crear(Compra compra);
        public void Actualizar(Compra compra);
        Task<Compra> GetCompraId(Guid CompraID);
        Task<bool> GuardarCambios();
    }
}
