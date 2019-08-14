using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias
{
    public class AgenciaViewModel
    {
        public AgenciaViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O número da agência  é requerido")]
        [Display(Name = "Número da Agência")]
        public int NumeroDaAgencia { get; set; }

        [Required(ErrorMessage = "O Nome da agência é requerido")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome da Agência")]
        public string NomeDaAgencia { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        public Guid? EnderecoId { get; set; }

        public BancoViewModel Banco { get; set; }
        public Guid BancoId { get; set; }

    }
}
