using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
            //Cidade = new CidadeViewModel();
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        [Key]
        public Guid Id { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public CidadeViewModel Cidade { get; set; }
        public Guid CidadeId { get; set; }

        public Guid? AgenciaId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public SelectList Estados()
        {
            return new SelectList(EstadoViewModel.ListarEstados(), "UF", "Nome");
        }
    }
}
