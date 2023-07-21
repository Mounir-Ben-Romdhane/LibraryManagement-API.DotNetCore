using GestionLivres.Repositories;

namespace GestionLivres.DataModels
{
    public interface IUnitOfWork: IDisposable
    { 
        IUserRepository UserRepository { get; }
        ILivreRepository LivreRepository { get; }

        int Complete();
        
    }
}
