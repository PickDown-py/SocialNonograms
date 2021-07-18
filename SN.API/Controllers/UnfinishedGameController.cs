using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnfinishedGameController : GenericController<UnfinishedGameEntity, int>
    {
        public UnfinishedGameController(IService<UnfinishedGameEntity, int> service) : base(service)
        {
        }
    }
}