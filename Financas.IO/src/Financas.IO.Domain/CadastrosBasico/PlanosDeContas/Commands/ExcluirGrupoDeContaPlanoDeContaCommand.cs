using System;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class ExcluirGrupoDeContaPlanoDeContaCommand:BaseGrupoDeContaPlanoDeContaCommand
    {
        public ExcluirGrupoDeContaPlanoDeContaCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
