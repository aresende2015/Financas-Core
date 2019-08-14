using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class CentroDeCustoContaCorrenteCadastradoEvent : BaseCentroDeCustoContaCorrenteEvent
    {
        public CentroDeCustoContaCorrenteCadastradoEvent(Guid id, string descricao, DateTime dataDeCadastro)
        {
            Id = id;
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
