using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class GrupoDeContaPlanoDeContaExcluidoEvent : BaseGrupoDeContaPlanoDeContaEvent
    {
        public GrupoDeContaPlanoDeContaExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
