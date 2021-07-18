using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridStateController: GenericController<GridStateEntity, int>
    {
        public GridStateController(IService<GridStateEntity, int> service) : base(service)
        {
        }
    }
}