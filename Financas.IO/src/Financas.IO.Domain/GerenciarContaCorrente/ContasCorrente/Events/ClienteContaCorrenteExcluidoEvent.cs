using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class ClienteContaCorrenteExcluidoEvent : BaseClienteContaCorrenteEvent
    {
        public ClienteContaCorrenteExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
