using Financas.IO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas
{
    public class PlanoDeContaViewModel
    {
        public PlanoDeContaViewModel()
        {
            Id = Guid.NewGuid();
            GrupoDeConta = new GrupoDeContaViewModel();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição do plano de conta é requerida")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public TipoDeMovimentacao TipoDeMovimento { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public GrupoDeContaViewModel GrupoDeConta { get; set; }
        public Guid GrupoDeContadId { get; set; }
    }
}
