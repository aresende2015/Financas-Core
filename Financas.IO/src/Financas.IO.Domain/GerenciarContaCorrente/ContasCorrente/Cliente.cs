using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente
{
    public class Cliente : Entity<Cliente>
    {
        #region Atributos da classe
        public string Nome { get; private set; }

        public string CPF { get; private set; }

        public string Email { get; private set; }

        public DateTime DataDeNascimento { get; private set; }
        #endregion

        #region Propriedades de navegação do EF
        public virtual ICollection<ContaCorrente> ContasCorrentes { get; private set; }
        #endregion

        public Cliente(string nome, string cpf, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        public Cliente()
        {

        }

        public void ExcluirCliente()
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
            ValidarNome();
            ValidarCPF();
            ValidarDataDeNascimento();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente precisa ser fornecido")
                .Length(2, 100).WithMessage("O nome do cliente precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarCPF()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("O CPF do cliente precisa ser fornecido")
                .Length(11, 11).WithMessage("O CPF tem que possuir 11 caracteres");
        }

        private void ValidarDataDeNascimento()
        {
            RuleFor(c => c.DataDeNascimento)
                .NotEmpty().WithMessage("A data de nascimento precisa ser fornecida")
                .Must(ClienteMaiorDeIdade).WithMessage("O Cliente deve ser maior de 18 anos");
        }

        private bool ClienteMaiorDeIdade(DateTime dataDeNascimento)
        {
            return dataDeNascimento <= DateTime.Now.AddYears(-18);
        }
        #endregion

        public static class ClienteFactory
        {
            public static Cliente NovoClienteCompleto(
                  Guid id,
                  string nome,
                  string cpf,
                  string email,
                  DateTime dataDeNascimento,
                  DateTime dataDeCadastro,
                  bool ativo)
            {
                var cliente = new Cliente()
                {
                    Id = id,
                    Nome = nome,
                    CPF = cpf,
                    Email = email,
                    DataDeNascimento = dataDeNascimento,
                    DataDeCadastro = DateTime.Now,
                    Ativo = true
                };

                //if (!ativo)
                //{
                //    cliente.DataDeCadastro = DateTime.Now;
                //    cliente.Ativo = true;
                //}

                return cliente;
            }
        }

    }
}
