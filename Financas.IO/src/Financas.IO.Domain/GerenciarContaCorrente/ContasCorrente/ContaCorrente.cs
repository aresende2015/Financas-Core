using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente
{
    public class ContaCorrente : Entity<ContaCorrente>
    {
        #region Atributos da classe
        public string NumeroDaContaCorrente { get; private set; }

        public Guid AgenciaId { get; private set; }

        public Guid ClienteId { get; private set; }
        #endregion

        #region Propriedades de navegação do EF
        public virtual Agencia Agencia { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public virtual ICollection<Lancamento> Lancamentos { get; private set; }
        #endregion

        public ContaCorrente(string numeroDaContaCorrente)
        {
            Id = Guid.NewGuid();
            NumeroDaContaCorrente = numeroDaContaCorrente;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        private ContaCorrente()
        {

        }

        public void ExcluirContaCorrente()
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
            ValidarNumeroDaContaCorrente();
        }

        private void ValidarNumeroDaContaCorrente()
        {
            RuleFor(cc => cc.NumeroDaContaCorrente)
                .NotEmpty().WithMessage("O número da conta corrente precisa ser preenchido")
                .Length(4, 10).WithMessage("O número da conta corrente precisa ter entre 4 e 10 caracteres");
        }
        #endregion

        public static class ContaCorrenteFactory
        {
            public static ContaCorrente NovaContaCorrenteCompleta(
                  Guid id,
                  string numeroDaContaCorrente,
                  DateTime dataDeCadastro,
                  bool ativo,
                  Guid agenciaId,
                  Guid clienteId)
            {
                var contaCorrente = new ContaCorrente()
                {
                    Id = id,
                    NumeroDaContaCorrente = numeroDaContaCorrente,
                    AgenciaId = agenciaId,
                    ClienteId = clienteId,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    contaCorrente.DataDeCadastro = DateTime.Now;
                //    contaCorrente.Ativo = true;
                //}

                return contaCorrente;
            }
        }
    }
}
