using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente
{
    public class CentroDeCustoViewModel
    {
        public CentroDeCustoViewModel()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O descrição do centro de custo é requerida")]
        [MinLength(3, ErrorMessage = "O tamanho minimo da descrição é {1}")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo da descrição é {1}")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
