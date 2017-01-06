using DAL.IRepositories;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IKbcUsuarioRepository KbcUsuarios { get; }
        IKbcPersonaRepository KbcPersonas { get; }
        IKbcPerfilRepository KbcPerfiles { get; }
        IKbcFuncionRepository KbcFunciones { get; }

        Task SaveChangesAsync();
        
    }
}