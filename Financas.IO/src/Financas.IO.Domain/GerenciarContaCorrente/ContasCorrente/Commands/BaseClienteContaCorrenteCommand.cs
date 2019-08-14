using Financas.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class BaseClienteContaCorrenteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string CPF { get; protected set; }

        public string Email { get; protected set; }
        
        public DateTime DataDeNascimento { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }
    }
}
