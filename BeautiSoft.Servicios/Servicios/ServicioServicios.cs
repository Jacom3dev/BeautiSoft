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
    public class ServicioServicios: IServicioServicios
    {
        private readonly AppDbContext _context;

        public ServicioServicios(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Servicio>> ListarServicio()
        {
            return await _context.Servicios.OrderBy(x => x.ServicioID).ToListAsync();
        }
        public void Crear(Servicio servicio)
        {
            if (servicio == null)

                throw new ArgumentNullException(nameof(servicio));
            servicio.ServicioID = Guid.NewGuid();
            servicio.Estado = true;
            _context.Add(servicio);
        }
        public void ActualizarServicio(Servicio servicio)
        {
            if (servicio == null)
                throw new ArgumentNullException(nameof(servicio));
            _context.Update(servicio);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Servicio> GetServicioId(Guid ServicioID)
        {
            return await _context.Servicios.FirstOrDefaultAsync(x => x.ServicioID == ServicioID);
        }


    }
}

