using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        public int idade { get; set; } 

        public string email { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public int CidadeCodigo { get; set; }

        public Cidade? Cidade { get; set; }  
    }
}
