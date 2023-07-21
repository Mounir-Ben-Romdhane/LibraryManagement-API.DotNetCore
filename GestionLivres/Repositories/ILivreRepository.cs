using GestionLivres.DataModels;
using GestionLivres.DomainModels;
using System.Collections;

namespace GestionLivres.Repositories
{
    public interface ILivreRepository
    {
        Task<ICollection> GetLivresAsync();
        Task<Livre> GetLivreAsync(int livreId);
        Task<List<Category>> GetAllCategory();
        Task<bool> Exist(int livreId);
        Task<Livre> UpdateLivreAsync(int livreId, Livre request);
        Task<Livre> DeleteLivreAsync(int livreId);
        Task<Livre> AddLivreAsync(Livre request);
        Task<bool> UpdateLivreImage(int livreId, string livreImageUrl);
        bool OrderBook(int userId, int livreId);
        IList<Order> GetOrdersOfUser(int userId);
        IList<Order> GetAllOrders();
        bool ReturnBook(int userId, int livreId);
        
    }
}
