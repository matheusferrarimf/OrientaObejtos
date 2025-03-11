using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Estado
    {
        [Key]
        [StringLength(2,MinimumLength = 2,ErrorMessage = "Sigla deve ter 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

    }
}
