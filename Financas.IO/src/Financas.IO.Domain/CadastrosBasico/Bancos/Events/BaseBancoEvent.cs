using Financas.IO.Domain.Core.Events;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Events
{
    public class BaseBancoEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
