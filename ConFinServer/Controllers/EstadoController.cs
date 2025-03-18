using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoController(AppDbContext context )
        {
            _context = context;
        }

        //private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public IActionResult GetEstado()
        {
            try
            {
                var lista = _context.Estado.OrderBy(e => e.Nome).ToList();
                //select * from estado order by nome
                return Ok(lista);
            }
            catch (Exception ex) 
            {
                return BadRequest("Erro ao consultar estado. " + ex.Message);
            }
            
        }

        //[HttpGet("Get2")]
        //public string GetEstado2()
        //{
        //    var valor = "teste";
        //    //f10 passa linha pr linha f9 pula tudo
        //    valor = valor + " - BSN 2";
        //    return valor;
        //}

        //[HttpGet("Lista")]
        //public List<Estado> GetLista()
        //{
        //    return lista;
        //}

        [HttpPost]
        public IActionResult PostEstado(Estado estado)
        {
            try
            {
                _context.Estado.Add(estado);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                return BadRequest("Erro ao inserir o Estado. " + ex.Message);
            }
            return Ok("Estado registrado com sucesso");
        }
        [HttpPut]
        public IActionResult PutEstado(Estado estado)
        {

            try
            {
                var estadoExiste = _context.Estado.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
                if (estadoExiste != null)
                {
                    estadoExiste.Nome = estado.Nome;
                    _context.Estado.Update(estadoExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Estado não encontrado!");
                }
                return Ok("Estado Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound("Estado não encontrado. " + ex.Message); 
            }
        }

        [HttpDelete]
        public string DeleteEstado([FromQuery]string sigla) //força a a buscar pelos objetos da requisição
        {
            var estadoExiste = _context.Estado.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                _context.Estado.Remove(estadoExiste);
                _context.SaveChanges();
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
            var estadoExiste = _context.Estado.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                _context.Estado.Remove(estadoExiste);
                _context.SaveChanges();
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
            var estadoExiste = _context.Estado.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                _context.Estado.Remove(estadoExiste);
                _context.SaveChanges();
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
            var estadoExiste = _context.Estado.Where(l => l.Sigla == sigla).FirstOrDefault();
            if (estadoExiste != null)
            {
                _context.Estado.Remove(estadoExiste);
                _context.SaveChanges();
            }
            else
            {
                return "Estado não encontrado!";
            }
            return "Estado excluido com sucesso!";
        }
    }
}
