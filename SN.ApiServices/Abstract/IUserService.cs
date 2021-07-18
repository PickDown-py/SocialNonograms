using System.Threading.Tasks;
using SN.Entity;

namespace SN.ApiServices.Abstract
{
    public interface IUserService : IService<UserEntity, int>
    {
        Task<bool> IsEmailValidAsync(string email);
        bool IsPasswordValid(string password);
        Task<bool> IsUserValidAsync(string email, string password);
        Task<UserEntity> GetByEmailAsync(string username);
    }
}