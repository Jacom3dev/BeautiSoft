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
    public class ClienteServicios: IClienteServicios
    {
        private readonly AppDbContext _context;

        public ClienteServicios(AppDbContext context)
        {
            _context = context;
        }
        //Crear Cliente
        public void Crear(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            cliente.Estado = true;
            _context.Add(cliente);
        }
        //Listar los clientes
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await _context.Clientes.Include(x => x.TipoDocument).ToListAsync();
        }

        //Listar Tipos de documentos
        public async Task<IEnumerable<TipoDocumento>> TiposDocumento()
        {
            return await _context.TiposDocumento.ToListAsync();
        }
        //Actulizar los clientes
        public void ActualizarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            _context.Update(cliente);
        }

        //Obtener los documentos para validar si existe el cliente
        public async Task<Cliente> GetClienteDocumento(string Documento)
        {
            if (Documento == null)
                throw new ArgumentNullException(nameof(Documento));

            return await _context.Clientes.Include(x => x.TipoDocument).FirstOrDefaultAsync(x => x.Documento == Documento);
        }
        // Guardar cambios
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
