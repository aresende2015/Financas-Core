using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos
{
    public class BancoViewModel
    {
        public BancoViewModel()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição do banco é requerida")]
        [MinLength(3, ErrorMessage = "O tamanho minimo da descrição é {1}")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo da descrição é {1}")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        //public SelectList Bancos()
        //{
        //    return new SelectList(ListarBancos(), "Id", "Descricao");
        //}

        //public List<BancoViewModel> ListarBancos()
        //{
        //    var bancosList = new List<BancoViewModel>()
        //    {
        //        new BancoViewModel(){ Id = new Guid("24FFFAC8-1646-4A03-844A-E5EEA4FD91CF"), Descricao = "Santander SA"}
        //    };

        //    return bancosList;
        //}
    }
}
