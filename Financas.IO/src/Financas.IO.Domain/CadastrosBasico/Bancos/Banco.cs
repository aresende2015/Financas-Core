using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.CadastrosBasico.Bancos
{
    public class Banco : Entity<Banco>
    {
        public string Descricao { get; private set; }

        public virtual ICollection<Agencia> Agencias { get; set; }

        public Banco(
            string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            Ativo = true;
        }

        // Contrutor para EF
        private Banco()
        {

        }

        public void ExcluirBanco()
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
            //
        }

        private void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O nome do banco precisa ser fornecido")
                .Length(2, 30).WithMessage("O nome do banco precisa ter entre 2 e 30 caracteres");
        }

        #endregion

        public static class BancoFactory
        {
            public static Banco NovoBancoCompleto(
                Guid id,
                string descricao,
                DateTime dataDeCadastro,
                bool ativo)
            {
                var banco = new Banco()
                {
                    Id = id,
                    Descricao = descricao,
                    DataDeCadastro = dataDeCadastro,
                    Ativo = ativo
                };

                //if (!ativo)
                //{
                //    banco.DataDeCadastro = DateTime.Now;
                //    banco.Ativo = true;
                //}

                return banco;
            }
        }
    }
}