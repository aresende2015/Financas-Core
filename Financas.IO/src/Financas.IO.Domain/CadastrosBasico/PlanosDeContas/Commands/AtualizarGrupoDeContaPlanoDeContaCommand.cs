using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class AtualizarGrupoDeContaPlanoDeContaCommand : BaseGrupoDeContaPlanoDeContaCommand
    {
        public AtualizarGrupoDeContaPlanoDeContaCommand(
            Guid id,
            string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
