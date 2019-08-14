using Financas.IO.Domain.Enums;
using System;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class CadastrarPlanoDeContaCommand: BasePlanoDeContaCommand
    {
        public CadastrarPlanoDeContaCommand(
            string descricao,
            TipoDeMovimentacao tipoDeMovimento,
            Guid grupoDecontaId,
            DateTime dataDeCadastro,
            bool ativo)
        {
            Descricao = descricao;
            TipoDeMovimento = tipoDeMovimento;
            GrupoDeContaId = grupoDecontaId;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
