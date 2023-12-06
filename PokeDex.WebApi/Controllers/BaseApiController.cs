using Microsoft.AspNetCore.Mvc;

namespace PokeDex.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
     
    }
}
