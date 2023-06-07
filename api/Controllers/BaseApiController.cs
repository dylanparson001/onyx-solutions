using Microsoft.AspNetCore.Mvc;
// Used for inheritance to controllers in order to prevent repeating boilerplate code
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}