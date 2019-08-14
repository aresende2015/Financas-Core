using System;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class CadastrarGrupoDeContaPlanoDeContaCommand: BaseGrupoDeContaPlanoDeContaCommand
    {
        public CadastrarGrupoDeContaPlanoDeContaCommand(string descricao, DateTime dataDeCadastro, bool ativo)
        {
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
