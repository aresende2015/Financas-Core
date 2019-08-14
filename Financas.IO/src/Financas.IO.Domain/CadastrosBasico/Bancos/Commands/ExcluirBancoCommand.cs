using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Commands
{
    public class ExcluirBancoCommand : BaseBancoCommand
    {
        public ExcluirBancoCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
