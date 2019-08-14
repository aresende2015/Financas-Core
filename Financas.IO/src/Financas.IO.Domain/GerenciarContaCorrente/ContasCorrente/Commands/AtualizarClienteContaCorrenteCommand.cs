using Financas.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class AtualizarClienteContaCorrenteCommand : BaseClienteContaCorrenteCommand
    {
        public AtualizarClienteContaCorrenteCommand(
            Guid id, string nome, string cpf, string email, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataDeNascimento = dataDeNascimento;
        }
    }
}
