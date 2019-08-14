using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class PlanoDeContaExcluidoEvent : BasePlanoDeContaEvent
    {
        public PlanoDeContaExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
