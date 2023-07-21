using GestionLivres.DomainModels;
using GestionLivres.Repositories;
using GestionLivres.UtilityService;

namespace GestionLivres.DataModels
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        

        public IUserRepository UserRepository => 
            new UserRepository(_context, _configuration, _emailService);
        public ILivreRepository LivreRepository => 
            new LivreRepository(_context);

        private readonly GestionLivresContext _context;
        public UnitOfWork(GestionLivresContext context)
        {
            _context = context;
            
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
    
}
