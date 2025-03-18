using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Conta
    {
        [Key]
        public int numero { get; set; }

        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Data {  get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Tipo Conta é obrigatório")]
        public TipoConta Tipo { get; set; } = TipoConta.Receber;

        [Required(ErrorMessage = "Situação é obrigatório")]
        public SituacaoConta Situacao { get; set; } = SituacaoConta.Aberta;

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int PessoaCodigo { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
