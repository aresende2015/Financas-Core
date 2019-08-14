using System;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class ExcluirContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public ExcluirContaCorrenteCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
