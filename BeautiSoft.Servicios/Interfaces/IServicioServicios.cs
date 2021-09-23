using BeautiSoft.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
   public interface IServicioServicios
   {
        void Crear(Servicio servicio);
        Task<IEnumerable<Servicio>> ListarServicio();
        void ActualizarServicio(Servicio servicio);
        Task<bool> GuardarCambios();
        Task<Servicio> GetServicioId(Guid ServicioID);
   }
}
