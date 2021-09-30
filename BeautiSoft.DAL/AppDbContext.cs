using BeautiSoft.Models.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.DAL
{
    public class AppDbContext :  IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Compra> Compras { get; set; } 

        public DbSet<Servicio> Servicios{ get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleCita> DetalleCitas { get; set; }

    }
}
