using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class FreseniusDbContext : DbContext
    {
        public FreseniusDbContext()
            : base("name=FreseniusDbContext")
        {            
        }

        public virtual DbSet<KbcUsuario> KbcUsuarios { get; set; }        
        public virtual DbSet<KbcPersona> KbcPersonas { get; set; }
        public virtual DbSet<KbcPerfil> KbcPerfils { get; set; }
        public virtual DbSet<KbcFuncion> KbcFuncion { get; set; }
    }
}
