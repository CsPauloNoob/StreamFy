using Microsoft.AspNetCore.Mvc;
using StreamFy.Api.RequestModels;
using StreamFy.Application;

namespace StreamFy.Api.Controllers
{
    [ApiController]
    [Route("autor")]
    public class AutorController : ControllerBase
    {
        private readonly PlaylistApplication _application;

        public AutorController(PlaylistApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorReq>>> GetAutores()
        {
            var resultado = await _application.RecuperarAutores();

            return Ok(resultado);
        }
    }
}
