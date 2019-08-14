using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Commands
{
    public class AtualizarBancoCommand : BaseBancoCommand
    {
        public AtualizarBancoCommand(
            Guid id,
            string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
