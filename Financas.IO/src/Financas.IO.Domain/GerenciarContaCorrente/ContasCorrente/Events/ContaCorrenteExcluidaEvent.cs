using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class ContaCorrenteExcluidaEvent : BaseContaCorrenteEvent
    {
        public ContaCorrenteExcluidaEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
