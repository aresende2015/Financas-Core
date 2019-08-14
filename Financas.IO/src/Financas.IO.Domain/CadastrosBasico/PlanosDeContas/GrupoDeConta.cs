using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas
{
    public class GrupoDeConta : Entity<GrupoDeConta>
    {
        #region Atributos da classe

        public string Descricao { get; private set; }

        #endregion

        #region Propriedades de navegação do EF

        public virtual ICollection<PlanoDeConta> PlanoDeContas { get; private set; }

        #endregion

        public GrupoDeConta(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        public GrupoDeConta()
        {

        }

        public void ExcluirGrupoDeConta()
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

            ValidationResult = Validate(this);

            // Validações adicionais
        }

        private void ValidarDescricao()
        {
            RuleFor(pc => pc.Descricao)
                .NotEmpty().WithMessage("A descrição precisa ser fornecida")
                .Length(2, 100).WithMessage("A descrição precisa ter entre 2 e 100 caracteres");
        }
        #endregion

        public static class GrupoDeContaFactory
        {
            public static GrupoDeConta NovoGrupoDeContaCompleto(
                Guid id,
                string descricao,
                DateTime dataDeCadastro,
                bool ativo)
            {
                var grupoDeConta = new GrupoDeConta()
                {
                    Id = id,
                    Descricao = descricao,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    grupoDeConta.DataDeCadastro = DateTime.Now;
                //    grupoDeConta.Ativo = true;
                //}

                return grupoDeConta;
            }
        }
    }
}
