using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class LancamentoContaCorrenteExcluidoEvent : BaseLancamentoContaCorrenteEvent
    {
        public LancamentoContaCorrenteExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;

        }
    }
}
