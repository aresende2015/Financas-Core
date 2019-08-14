using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Events
{
    public class BancoExcluidoEvent : BaseBancoEvent
    {
        public BancoExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
