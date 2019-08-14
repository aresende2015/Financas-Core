using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11)]
        [Required(ErrorMessage = "O CPF é requerido")]
        public string CPF { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O e-mail é requerido")]
        [EmailAddress(ErrorMessage ="E-mail em formato inválido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A data de nascimento é requerida")]
        [DataType(DataType.Date, ErrorMessage ="Data em formato inválido")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
