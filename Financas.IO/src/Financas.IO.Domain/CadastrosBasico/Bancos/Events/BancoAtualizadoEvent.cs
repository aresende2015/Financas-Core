using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Events
{
    public class BancoAtualizadoEvent : BaseBancoEvent
    {
        public BancoAtualizadoEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;

            AggregateId = id;

        }
    }
}
