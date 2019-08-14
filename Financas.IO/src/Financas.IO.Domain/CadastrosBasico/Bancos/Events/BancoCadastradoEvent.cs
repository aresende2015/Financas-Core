using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Events
{
    public class BancoCadastradoEvent : BaseBancoEvent
    {
        public BancoCadastradoEvent(Guid id, string descricao, DateTime dataDeCadastro)
        {
            Id = id;
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;

        }
    }
}
