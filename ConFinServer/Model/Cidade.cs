using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Cidade
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Sigla deve ter 2 caracteres")]
        public string EstadoSigla { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        
        public Estado? Estado { get; set; }

    }
}
