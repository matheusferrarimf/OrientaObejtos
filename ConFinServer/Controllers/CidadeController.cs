using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        }

        //private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public IActionResult GetEstado()
        {
            try
            {
                var lista = _context.Cidade.Include(c => c.Estado).OrderBy(c => c.Nome).ToList();
                //select * from estado order by nome
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao consultar cidade. " + ex.Message);
            }

        }


        [HttpPost]
        public IActionResult PostCidade(Cidade cidade)
        {
            try
            {
                _context.Cidade.Add(cidade);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir a cidade. " + ex.Message);
            }
            return Ok("Cidade registrada com sucesso");
        }

        [HttpPut]
        public IActionResult PutCidade(Cidade cidade)
        {
            

            try
            {
                var cidadeExiste = _context.Cidade.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
                if (cidadeExiste != null)
                {
                    cidadeExiste.Nome = cidade.Nome;
                    cidadeExiste.EstadoSigla = cidade.EstadoSigla;
                    _context.Cidade.Update(cidadeExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Cidade não encontrada!");
                }
                return Ok("Cidade Alterada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Cidade não encontrada. " + ex.Message);
            }
        }

        [HttpDelete]
        public string DeleteCidade([FromQuery] int codigo) //força a a buscar pelos objetos da requisição
        {
            var cidadeExiste = _context.Cidade.Where(l => l.Codigo == codigo).FirstOrDefault();
            if (cidadeExiste != null)
            {
                _context.Cidade.Remove(cidadeExiste);
                _context.SaveChanges();
            }
            else
            {
                return "Cidade não encontrada!";
            }
            return "Cidade excluida com sucesso!";
        }
    }
}
