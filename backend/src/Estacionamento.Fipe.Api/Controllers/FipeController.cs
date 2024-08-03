using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Fipe.Api.Controllers
{
    [Route("api/v1/fipe")]
    [ApiController]
    public class FipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
