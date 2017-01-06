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
    public class KbcFuncionRepository : Repository<KbcFuncion>, IKbcFuncionRepository
    {
        public KbcFuncionRepository(FreseniusDbContext context) 
            : base(context)
        {
        }
    }
}
