using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class BaseClienteContaCorrenteEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string CPF { get; protected set; }

        public string Email { get; protected set; }

        public DateTime DataDeNascimento { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
