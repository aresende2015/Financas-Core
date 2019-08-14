using Financas.IO.Domain.Core.Models;
using Financas.IO.Domain.Enums;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas
{
    public class PlanoDeConta : Entity<PlanoDeConta>
    {
        #region Atributos da classe

        public string Descricao { get; private set; }

        public TipoDeMovimentacao TipoDeMovimento { get; private set; }

        public Guid GrupoDeContaId { get; private set; }

        #endregion

        #region Propriedades de navegação do EF

        public virtual GrupoDeConta GrupoDeConta { get; private set; }

        public virtual ICollection<Lancamento> Lancamentos { get; private set; }

        #endregion

        public PlanoDeConta(string descricao, TipoDeMovimentacao tipoDeMovimento)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            TipoDeMovimento = tipoDeMovimento;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        public PlanoDeConta()
        {

        }

        public void ExcluirPlanoDeConta()
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

        public static class PlanoDeContaFactory
        {
            public static PlanoDeConta NovoPlanoDeContaCompleto(
                Guid id,
                string descricao,
                TipoDeMovimentacao tipoDeMovimento,
                Guid grupoDeContaId,
                DateTime dataDeCadastro,
                bool ativo)
            {
                var planoDeConta = new PlanoDeConta()
                {
                    Id = id,
                    Descricao = descricao,
                    TipoDeMovimento = tipoDeMovimento,
                    GrupoDeContaId = grupoDeContaId,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    planoDeConta.DataDeCadastro = DateTime.Now;
                //    planoDeConta.Ativo = true;
                //}

                return planoDeConta;
            }
        }
    }
}
