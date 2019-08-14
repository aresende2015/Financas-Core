using System;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class ExcluirClienteContaCorrenteCommand : BaseClienteContaCorrenteCommand
    {
        public ExcluirClienteContaCorrenteCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
