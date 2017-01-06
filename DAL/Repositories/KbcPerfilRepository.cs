using DAL.Repositories;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KbcPerfilRepository : Repository<KbcPerfil>, IKbcPerfilRepository
    {
        public KbcPerfilRepository(FreseniusDbContext context) 
            : base(context)
        {
        }
    }
}
