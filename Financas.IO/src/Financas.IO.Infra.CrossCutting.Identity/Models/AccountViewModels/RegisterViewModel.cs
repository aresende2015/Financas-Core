using System;
using System.ComponentModel.DataAnnotations;

namespace Financas.IO.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11)]
        [Required(ErrorMessage = "O CPF é requerido")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A data de nascimento é requerida")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="E-mail em formato inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
