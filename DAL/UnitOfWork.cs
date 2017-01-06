using DAL.Repositories;
using DAL.IRepositories;
using System;
using System.Threading.Tasks;
namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private fields

        private readonly FreseniusDbContext context;
        private bool disposed = false;

        #endregion

        #region public fields

        public IKbcUsuarioRepository KbcUsuarios { get; private set; }
        public IKbcPersonaRepository KbcPersonas { get; private set; }
        public IKbcPerfilRepository KbcPerfiles { get; private set; }
        public IKbcFuncionRepository KbcFunciones { get; private set; }

        #endregion

        #region Constructor

        public UnitOfWork()
        {
            this.context = new FreseniusDbContext();
            KbcUsuarios = new KbcUsuarioRepository(this.context);
            KbcPersonas = new KbcPersonaRepository(this.context);
            KbcPerfiles = new KbcPerfilRepository(this.context);
            KbcFunciones = new KbcFuncionRepository(this.context);
            
        }

        #endregion

        #region protected method

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion

        #region public method

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion        
    }
}