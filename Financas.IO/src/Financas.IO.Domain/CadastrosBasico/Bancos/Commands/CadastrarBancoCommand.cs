using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Commands
{
    public class CadastrarBancoCommand : BaseBancoCommand
    {
        public CadastrarBancoCommand(
            string descricao,
            DateTime dataDeCadastro,
            bool ativo)
        {
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
