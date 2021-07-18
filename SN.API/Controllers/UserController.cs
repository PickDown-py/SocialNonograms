using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericController<UserEntity, int>
    {
        public UserController(IService<UserEntity, int> service) : base(service)
        {
        }
    }
}