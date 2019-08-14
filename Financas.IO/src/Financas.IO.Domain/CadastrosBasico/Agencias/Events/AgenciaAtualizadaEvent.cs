using Financas.IO.Domain.CadastrosBasico.Agencias.Events;
using System;

namespace Financas.IO.Domain.AgenCadastrosBasico.Agenciascias.Events
{
    public class AgenciaAtualizadaEvent : BaseAgenciaEvent
    {
        public AgenciaAtualizadaEvent(Guid id, int numeroDaAgencia, string nomeDaAgencia)
        {
            Id = id;
            NumeroDaAgencia = numeroDaAgencia;
            NomeDaAgencia = nomeDaAgencia;

            AggregateId = id;

        }

    }
}
