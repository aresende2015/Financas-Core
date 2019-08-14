using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class ExcluirCentroDeCustoContaCorrenteCommand : BaseCentroDeCustoContaCorrenteCommand
    {
        public ExcluirCentroDeCustoContaCorrenteCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
