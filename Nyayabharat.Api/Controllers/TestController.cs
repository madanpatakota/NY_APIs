using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nyayabharat.Api.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController: ControllerBase
    {
        [HttpGet]
        [Route("GetName")]
        public string GetName()
        {
            return "Madan";
        }
    }
}
