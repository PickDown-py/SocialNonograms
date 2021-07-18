using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankController: GenericController<RankEntity, int>
    {
        public RankController(IService<RankEntity, int> service) : base(service)
        {
        }
    }
}