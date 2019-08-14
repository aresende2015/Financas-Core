using System;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class ExcluirPlanoDeContaCommand : BasePlanoDeContaCommand
    {
        public ExcluirPlanoDeContaCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
