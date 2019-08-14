using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class CadastrarContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public CadastrarContaCorrenteCommand(
            string numeroDaContaCorrente,
            Guid agenciaId,
            Guid clienteId,
            DateTime dataDeCadastro,
            bool ativo)
        {
            NumeroDaContaCorrente = numeroDaContaCorrente;
            AgenciaId = agenciaId;
            ClienteId = clienteId;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }
    }
}
