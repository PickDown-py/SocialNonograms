using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SN.ApiServices.Abstract;
using SN.DAL.Abstract;
using SN.Entity;

namespace SN.ApiServices
{
    public class UserService: GenericService<UserEntity, int>, IUserService
    {
        public UserService(IRepository<UserEntity, int> repository) : base(repository)
        {
            
        }

        public async Task<bool> IsUserValidAsync(string email, string password)
        {
            return await Repository.Get(u => u.Login == email && u.Password == password) != null;
        }
        
        public async Task<bool> IsEmailValidAsync(string email)
        {
            return await Repository.Get(u => u.Login == email) == null;
        }

        public bool IsPasswordValid(string password)
        {
            var regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password);
        }

        public async Task<UserEntity> GetByEmailAsync(string username)
        {
            return await Repository.Get(u => u.Login == username);
        }
    }
}