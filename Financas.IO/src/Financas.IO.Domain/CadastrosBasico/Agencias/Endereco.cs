using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string CEP { get; private set; }

        public Guid CidadeId { get; private set; }

        public Guid? AgenciaId { get; private set; }

        // EF propriedades de navegação
        public virtual Cidade Cidade { get; private set; }

        public virtual Agencia Agencia { get; private set; }

        public Endereco(Guid id, 
                        string logradouro, 
                        string numero, 
                        string complemento, 
                        string bairro, 
                        string cep,
                        DateTime dataDeCadastro,
                        bool ativo,
                        Guid cidadeId, 
                        Guid agenciaId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
            CidadeId = cidadeId;
            AgenciaId = agenciaId;
        }

        // Construtor para o EF
        protected Endereco()
        {

        }

        public void AtribuirCidade(Cidade cidade)
        {
            if (!cidade.EhValido()) return;

            Cidade = cidade;
        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumero();
            ValidarBairro();
            ValidarCEP();

            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O Logradouro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Logradouro precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarNumero()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O Numero precisa ser fornecido")
                .Length(1, 10).WithMessage("O Numero precisa ter entre 1 e 10 caracteres");
        }

        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O Bairro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Bairro precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarCEP()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O CEP precisa ser fornecido")
                .Length(8).WithMessage("O CEP precisa ter 8 caracteres");
        }

        #endregion
    }
}