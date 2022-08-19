using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreController : ControllerBase
    {
        [HttpGet]
        public string GetName() => "Hello";
    }
}
