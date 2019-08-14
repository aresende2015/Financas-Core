using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class CentroDeCustoContaCorrenteExcluidoEvent : BaseCentroDeCustoContaCorrenteEvent
    {
        public CentroDeCustoContaCorrenteExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
