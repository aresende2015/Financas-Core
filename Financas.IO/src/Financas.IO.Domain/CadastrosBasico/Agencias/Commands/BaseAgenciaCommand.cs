using Financas.IO.Domain.Core.Commands;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Commands
{
    public abstract class BaseAgenciaCommand : Command
    {
        public Guid Id { get; protected set; }

        public int NumeroDaAgencia { get; protected set; }

        public string NomeDaAgencia { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }

        public Guid BancoId { get; protected set; }


    }
}
