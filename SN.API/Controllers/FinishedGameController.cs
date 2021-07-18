using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinishedGameController: GenericController<FinishedGameEntity, int>
    {
        public FinishedGameController(IService<FinishedGameEntity, int> service) : base(service)
        {
        }
    }
}