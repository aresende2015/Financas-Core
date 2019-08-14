using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class CentroDeCustoContaCorrenteAtualizadoEvent : BaseCentroDeCustoContaCorrenteEvent
    {
        public CentroDeCustoContaCorrenteAtualizadoEvent(Guid id, string descricao, DateTime dataDeCadastro)
        {
            Id = id;
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
