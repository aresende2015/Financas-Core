using Financas.IO.Domain.Core.Commands;
using System;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class CadastrarClienteContaCorrenteCommand : BaseClienteContaCorrenteCommand
    {
        public CadastrarClienteContaCorrenteCommand(
            string nome, string cpf, string email, DateTime dataDeNascimento, DateTime dataDeCadastro, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
