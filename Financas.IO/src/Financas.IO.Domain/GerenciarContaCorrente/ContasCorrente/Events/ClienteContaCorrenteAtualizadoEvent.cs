using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class ClienteContaCorrenteAtualizadoEvent : BaseClienteContaCorrenteEvent
    {
        public ClienteContaCorrenteAtualizadoEvent(
            Guid id, string nome, string cpf, string email,
            DateTime dataDeNascimento, DateTime dataDeCadastro)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
