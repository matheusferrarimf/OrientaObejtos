using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> lista = new List<Cidade>();

        [HttpGet("Lista")]
        public List<Cidade> GetLista()
        {
            return lista;
        }

        [HttpPost]
        public string PostCidade(Cidade cidade)
        {
            lista.Add(cidade);
            return "Cidade cadastrada com sucesso!";
        }

        [HttpPut]
        public string PutCidade(Cidade cidade)
        {
            var cidadeExiste = lista.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
            if (cidadeExiste != null)
            {
                cidadeExiste.Codigo = cidade.Codigo;
                cidadeExiste.Estado = cidade.Estado;
                cidadeExiste.Nome = cidade.Nome;
            }
            else
            {
                return "Cidade não encontrada!";
            }
            return "Cidade Alterada com sucesso!";
        }

        [HttpDelete("Objeto")]
        public string DeleteCidade([FromBody] Cidade cidade) //frombody força a buscar pelo corpo da requisição
        {
            var cidadeExiste = lista.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
            if (cidadeExiste != null)
            {
                lista.Remove(cidadeExiste);
            }
            else
            {
                return "Cidade não encontrada!";
            }
            return "Cidade excluida com sucesso!";
        }
    }
}
