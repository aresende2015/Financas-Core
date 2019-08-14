using Financas.IO.Domain.Core.Events;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Events
{
    public class BaseAgenciaEvent : Event
    {
        public Guid Id { get; protected set; }

        public int NumeroDaAgencia { get; protected set; }

        public string NomeDaAgencia { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
