using GestionLivres.DomainModels;
using GestionLivres.DomainModels.Dto;
using System.Security.Claims;

namespace GestionLivres.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> Authenticate(string username);
        Task<User> RegisterUser(User request);

        Task<User> GetUserAsync(int userId);
        Task<User> UpdateUserAsync(int userId, UpdateUserRequest request);
        Task<User> DeleteUserAsync(int userId);
        Task<User> AddUserAsync(User request);
        Task<bool>  ExistUser(int userId);
        Task<List<Role>> GetAllRoles();

        Task<string> GetAllCLaims(Guid roleId);
        Task<bool> CheckUserNameExistAsync(string username);
        Task<bool> CheckEmailExistAsync(string email);
        string CheckPasswordStrengthAsync(string password);
        string CreateJwtToken(User user);
        string CreateRefreshToken();
        Task<User> RefreshToken(TokenApiDto tokenApiDto);
        ClaimsPrincipal GetPrincipaleFromExpireToken(string token);

        Task<User> GetUserByEmail(string email);

        Task SendEmail( User user);
        Task<User> GetUserByEmailToken(string emailToken);

        Task SendResetEmail(User user);

        Task<IList<User>> GetUsers();
        void BlockUser(int userId);
        void UnBlockUser(int userId);
        void DesactivateUser(int userId);
        void ActivateUser(int userId);
    }
}
