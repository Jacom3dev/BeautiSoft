using BeautiSoft.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
    public interface IClienteServicios
    {
        Task<IEnumerable<TipoDocumento>> TiposDocumento();
        void Crear(Cliente cliente);
        Task<IEnumerable<Cliente>> ListarClientes();
        Task<Cliente> GetClienteId(string Documento);
        Task<bool> GuardarCambios();
    }
}
