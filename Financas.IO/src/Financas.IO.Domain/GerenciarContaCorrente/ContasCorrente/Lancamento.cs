using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente
{
    public class Lancamento : Entity<Lancamento>
    {
        #region Atributos da classe

        public int Sequencial { get; private set; }

        public string Observacao { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataDoLancamento { get; private set; }

        public int Competencia { get; private set; }

        public Guid CentroDeCustoId { get; private set; }

        public Guid PlanoDeContaId { get; private set; }

        public Guid ContaCorrenteId { get; private set; }

        #endregion

        #region Propriedades de navegação do EF

        public virtual CentroDeCusto CentroDeCusto { get; private set; }

        public virtual PlanoDeConta PlanoDeConta { get; private set; }

        public virtual ContaCorrente ContaCorrente { get; private set; }

        #endregion

        public Lancamento(int sequencial, string observacao, decimal valor,
                    DateTime dataDoLancamento, int competencia, Guid centroDeCustoId,
                    Guid planoDeContaId, Guid contaCorrenteId)
        {
            Id = Guid.NewGuid();
            Sequencial = sequencial;
            Observacao = observacao;
            Valor = valor;
            DataDoLancamento = dataDoLancamento;
            Competencia = competencia;
            CentroDeCustoId = centroDeCustoId;
            PlanoDeContaId = planoDeContaId;
            ContaCorrenteId = contaCorrenteId;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        public Lancamento()
        {

        }

        public void ExcluirLancamento()
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
            ValidarCompetencia();
        }

        private void ValidarCompetencia()
        {
            RuleFor(l => l.Competencia)
                    .ExclusiveBetween(201801, 204912)
                    .WithMessage("A competência deve estar entre janeiro de 2018 até dezembro de 2049");
        }
        #endregion

        public static class LancamentoFactory
        {
            public static Lancamento NovoCentroDeCustoCompleto(
                  Guid id,
                  int sequencial,
                  string observacao,
                  decimal valor,
                  DateTime dataDoLancamento,
                  int competencia,
                  Guid centroDeCustoId,
                  Guid planoDeContaId,
                  Guid contaCorrenteId,
                  DateTime dataDeCadastro,
                  bool ativo)
            {
                var lancamento = new Lancamento()
                {
                    Id = id,
                    Sequencial = sequencial,
                    Observacao = observacao,
                    Valor = valor,
                    DataDoLancamento = dataDoLancamento,
                    Competencia = competencia,
                    CentroDeCustoId = centroDeCustoId,
                    PlanoDeContaId = planoDeContaId,
                    ContaCorrenteId = contaCorrenteId,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    lancamento.DataDeCadastro = DateTime.Now;
                //    lancamento.Ativo = true;
                //}

                return lancamento;
            }
        }
    }
}
