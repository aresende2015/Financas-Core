using System;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class CadastrarCentroDeCustoContaCorrenteCommand : BaseCentroDeCustoContaCorrenteCommand
    {
        public CadastrarCentroDeCustoContaCorrenteCommand(string descricao, DateTime dataDeCadastro, bool ativo)
        {
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
