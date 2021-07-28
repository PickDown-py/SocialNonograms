using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SN.API.Controllers.Abstract;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    [Route("api/[controller]")]
    public class GameController: GenericController<GameEntity, int>
    {
        public GameController(IGameService service) : base(service)
        {
            
        }
    }
}