using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public string GetEstado()
        {
            var valor = "teste";
            //f10 passa linha pr linha f9 pula tudo
            valor = valor + " - BSN";
            return valor;
        }

        [HttpGet("Get2")]
        public string GetEstado2()
        {
            var valor = "teste";
            //f10 passa linha pr linha f9 pula tudo
            valor = valor + " - BSN 2";
            return valor;
        }
    }
}
