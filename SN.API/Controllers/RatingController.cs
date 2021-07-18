using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController: GenericController<RatingEntity, int>
    {
        public RatingController(IService<RatingEntity, int> service) : base(service)
        {
        }
    }
}