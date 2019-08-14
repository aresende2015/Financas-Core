using Financas.IO.Domain.Core.Commands;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Commands
{
    public abstract class BaseBancoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }
    }
}
