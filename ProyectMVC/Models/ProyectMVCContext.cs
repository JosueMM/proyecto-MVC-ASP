using Microsoft.EntityFrameworkCore;
using ProyectMVC.Models;


namespace ProyectMVC.Models
{
    public class ProyectMVCContext : DbContext
    {
         public ProyectMVCContext (DbContextOptions<ProyectMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Models.ClienteModel> Cliente { get; set; }
        public DbSet<Models.ContactoModel> Contacto { get; set; }
        public DbSet<Models.ReunionModel> Reunion { get; set; }
        public DbSet<Models.SectorModel> Sector { get; set; }
        public DbSet<ProyectMVC.Models.SupportModel> SupportModel { get; set; }
        public DbSet<ProyectMVC.Models.UsuarioModel> UsuarioModel { get; set; }
    }
}
