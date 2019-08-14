using Financas.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class BaseContaCorrenteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string NumeroDaContaCorrente { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }

        public Guid AgenciaId { get; protected set; }

        public Guid ClienteId { get; protected set; }
    }
}
