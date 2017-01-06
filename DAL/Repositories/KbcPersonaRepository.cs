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
    public class KbcPersonaRepository : Repository<KbcPersona>, IKbcPersonaRepository
    {
        public KbcPersonaRepository(FreseniusDbContext context) 
            : base(context)
        {
        }
    }
}
