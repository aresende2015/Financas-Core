using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class ExcluirLancamentoContaCorrenteCommand : BaseLancamentoContaCorrenteCommand
    {
        public ExcluirLancamentoContaCorrenteCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
