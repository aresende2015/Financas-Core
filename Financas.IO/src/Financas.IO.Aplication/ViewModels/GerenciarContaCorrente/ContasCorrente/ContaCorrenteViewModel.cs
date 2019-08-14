using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente
{
    public class ContaCorrenteViewModel
    {
        public ContaCorrenteViewModel()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
            Agencia = new AgenciaViewModel();
            Cliente = new ClienteViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O número da conta é requerido")]
        [MinLength(4, ErrorMessage = "O tamanho minimo do número da conta é {1}")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo do número da conta é {1}")]
        [Display(Name = "Número da Conta")]
        public string NumeroDaContaCorrente { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public AgenciaViewModel Agencia { get; set; }
        public Guid AgenciaId { get; set; }

        public ClienteViewModel Cliente { get; set; }
        public Guid ClienteId { get; set; }

    }
}
