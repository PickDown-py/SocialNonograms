using System.Threading.Tasks;
using SN.Model;

namespace SN.ClientServices.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> LoginAsync(AuthenticationUserModel authenticationUserModel);
        Task LogoutAsync();
    }
}