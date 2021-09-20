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
        public async Task<IEnumerable<TipoDocumento>> TiposDocumento()
        {
            return await _context.TiposDocumento.ToListAsync();
        }

        public void Crear(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            cliente.Estado = true;
            _context.Add(cliente);
        }
        //this metod is for get clients.
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await _context.Clientes.Include(x =>x.TipoDocument).ToListAsync();
        }
        public async Task<Cliente> GetClienteId(string Documento)
        {
            if (Documento == null)
                throw new ArgumentNullException(nameof(Documento));

            return await _context.Clientes.Include(x => x.TipoDocument).FirstOrDefaultAsync(x => x.Documento == Documento);
        }
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
