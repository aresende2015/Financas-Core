using Financas.IO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class AtualizarPlanoDeContaCommand : BasePlanoDeContaCommand
    {
        public AtualizarPlanoDeContaCommand(
            Guid id,
            string descricao,
            TipoDeMovimentacao tipoDeMovimento,
            Guid grupoDeContaId)
        {
            Id = id;
            Descricao=descricao;
            TipoDeMovimento = tipoDeMovimento;
            GrupoDeContaId = grupoDeContaId;
        }
    }
}
