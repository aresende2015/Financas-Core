using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Events
{
    public class AgenciaExcluidaEvent : BaseAgenciaEvent
    {
        public AgenciaExcluidaEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
