using AutoMapper;
using Financas.IO.Domain.CadastrosBasico.Agencias.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias
{
    public class CidadeViewModel
    {

        //public CidadeViewModel()
        //{
        //    Id = Guid.NewGuid();
        //    DataDeCadastro = DateTime.Now;
        //    Ativo = true;
        //}

        [Key]
        public Guid Id { get; set; }

        public int CodigoIBGE { get; set; }

        public string Descricao { get; set; }

        public string UF { get; set; }

        public bool IsCapital { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

    }
}
