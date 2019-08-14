using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Commands
{
    public class ExcluirAgenciaCommand : BaseAgenciaCommand
    {
        public ExcluirAgenciaCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
