using Financas.IO.Domain.CadastrosBasico.Bancos;
using Financas.IO.Domain.Core.Models;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.CadastrosBasico.Agencias
{
    public class Agencia : Entity<Agencia>
    {
        #region Atributos da classe
        public int NumeroDaAgencia { get; private set; }

        public string NomeDaAgencia { get; private set; }

        public Guid? EnderecoId { get; private set; }

        public Guid BancoId { get; private set; }
        #endregion


        #region Propriedades de navegação do EF
        public virtual Endereco Endereco { get; private set; }

        public virtual Banco Banco { get; private set; }

        public virtual ICollection<ContaCorrente> ContasCorrentes { get; private set; }
        #endregion


        public Agencia(
            int numeroDaAgencia,
            string nomeDaAgencia)
        {
            Id = Guid.NewGuid();
            NumeroDaAgencia = numeroDaAgencia;
            NomeDaAgencia = nomeDaAgencia;
            DataDeCadastro = DateTime.Now;
            Ativo = true;

        }

        // Contrutor para EF
        private Agencia()
        {

        }


        public void AtribuirEnderco(Endereco endereco)
        {
            if (!endereco.EhValido()) return;

            Endereco = endereco;
        }

        public void AtribuirBanco(Banco banco)
        {
            if (!banco.EhValido()) return;

            Banco = banco;
        }

        public void ExcluirAgencia()
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
            ValidarNumeroDaAgencia();
            ValidarNomeDaAgencia();

            ValidationResult = Validate(this);

            // Validações adicionais
            ValidarEndereco();
        }

        private void ValidarNumeroDaAgencia()
        {
            RuleFor(c => c.NumeroDaAgencia)
                .ExclusiveBetween(1000, 9999).WithMessage("O número da agência deve conter 4 dígitos");
        }

        private void ValidarNomeDaAgencia()
        {
            RuleFor(c => c.NomeDaAgencia)
                .NotEmpty().WithMessage("O nome da agência precisa ser fornecido")
                .Length(2, 50).WithMessage("O nome da agência precisa ter entre 2 e 50 caracteres");
        }

        private void ValidarEndereco()
        {
            if (Endereco.EhValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }
        #endregion

        public static class AgenciaFactory
        {
            public static Agencia NovaAgenciaCompleta(
                Guid id,
                int numeroDaAgencia,
                string nomeDaAgencia,
                DateTime dataDeCadastro,
                bool ativo,
                Endereco endereco,
                Guid bancoId)
            {
                var agencia = new Agencia()
                {
                    Id = id,
                    NumeroDaAgencia = numeroDaAgencia,
                    NomeDaAgencia = nomeDaAgencia,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true,
                    Endereco = endereco,
                    BancoId = bancoId
                };

                return agencia;
            }
        }
    }
}
