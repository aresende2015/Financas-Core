using Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente
{
    public class LancamentoViewModel
    {
        public LancamentoViewModel()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
            CentroDeCusto = new CentroDeCustoViewModel();
            PlanoDeConta = new PlanoDeContaViewModel();
            ContaCorrente = new ContaCorrenteViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public int Sequencial { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Data do Lançamento")]
        [Required(ErrorMessage = "A data do lançamento é requerida")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDoLancamento { get; set; }

        [ScaffoldColumn(false)]
        public int Competencia { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public CentroDeCustoViewModel CentroDeCusto { get; set; }
        public Guid CentroDeCustoId { get; set; }

        public PlanoDeContaViewModel PlanoDeConta { get; set; }
        public Guid PlanoDeContaId { get; set; }

        public ContaCorrenteViewModel ContaCorrente { get; set; }
        public Guid ContaCorrenteId { get; set; }
    }
}
