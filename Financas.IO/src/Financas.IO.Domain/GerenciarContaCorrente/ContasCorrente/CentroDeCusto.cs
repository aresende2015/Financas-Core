using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente
{
    public class CentroDeCusto : Entity<CentroDeCusto>
    {
        #region Atributos da classe

        public string Descricao { get; private set; }

        #endregion

        #region Propriedades de navegação do EF

        public virtual ICollection<Lancamento> Lancamentos { get; private set; }

        #endregion

        public CentroDeCusto(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        public CentroDeCusto()
        {

        }

        public void ExcluirCentroDeCusto()
        {
            // TODO: Deve validar alguma regra

            Ativo = false;
        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarDescricao();
        }

        private void ValidarDescricao()
        {
            RuleFor(cc => cc.Descricao)
                .NotEmpty().WithMessage("A descrição precisa ser fornecido")
                .Length(2, 100).WithMessage("A descrição precisa ter entre 2 e 100 caracteres");
        }
        #endregion

        public static class CentroDeCustoFactory
        {
            public static CentroDeCusto NovoCentroDeCustoCompleto(
                  Guid id,
                  string descricao,
                  DateTime dataDeCadastro,
                  bool ativo)
            {
                var centroDeCusto = new CentroDeCusto()
                {
                    Id = id,
                    Descricao = descricao,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    centroDeCusto.DataDeCadastro = DateTime.Now;
                //    centroDeCusto.Ativo = true;
                //}

                return centroDeCusto;
            }
        }
    }
}
