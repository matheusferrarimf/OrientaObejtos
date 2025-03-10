using ConFinServer.Model;
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

        [HttpGet("Lista")]
        public List<Estado> GetLista()
        {
            return lista;
        }

        [HttpPost]
        public string PostEstado(Estado estado)
        {
            lista.Add(estado);
            return "Estado cadastrado com sucesso!";
        }
        [HttpPut]
        public string PutEstado(Estado estado)
        {
            var estadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                estadoExiste.Sigla = estado.Sigla;
                estadoExiste.Nome = estado.Nome;
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado Alterado com sucesso!";
        }

        [HttpDelete]
        public string DeleteEstado([FromQuery]string sigla) //força a a buscar pelos objetos da requisição
        {
            var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado excluido com sucesso!";
        }

        [HttpDelete("Objeto")]
        public string DeleteEstado([FromBody]Estado estado) //frombody força a buscar pelo corpo da requisição
        {
            var estadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado excluido com sucesso!";
        }

        [HttpDelete("Header")]
        public string DeleteEstado3([FromHeader] string sigla) //força a buscar pelo cabeçario da requisição
        {
            var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado excluido com sucesso!";
        }

        [HttpDelete("{sigla}")]
        public string DeleteEstado4([FromRoute] string sigla) //força a buscar pela rota da requisição
        {
            var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado excluido com sucesso!";
        }
    }
}
