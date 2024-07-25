using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Interfaces;
using Estacionamento.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private IBaseService<Veiculo> _baseVeiculoService;

        public VeiculoController(IBaseService<Veiculo> baseVeiculoService)
        {
            _baseVeiculoService = baseVeiculoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Veiculo veiculo)
        {
            if (veiculo is null)
                return NotFound();

            return Ok(() => _baseVeiculoService.Add<VeiculoValidator>(veiculo).Id);
        }

        //[HttpPut]
        //public IActionResult Update([FromBody] User user)
        //{
        //    if (user == null)
        //        return NotFound();

        //    return Execute(() => _baseUserService.Update<UserValidator>(user));
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id == 0)
        //        return NotFound();

        //    Execute(() =>
        //    {
        //        _baseUserService.Delete(id);
        //        return true;
        //    });

        //    return new NoContentResult();
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Execute(() => _baseUserService.Get());
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    if (id == 0)
        //        return NotFound();

        //    return Execute(() => _baseUserService.GetById(id));
        //}

        //private IActionResult Execute(Func<object> func)
        //{
        //    try
        //    {
        //        var result = func();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}
