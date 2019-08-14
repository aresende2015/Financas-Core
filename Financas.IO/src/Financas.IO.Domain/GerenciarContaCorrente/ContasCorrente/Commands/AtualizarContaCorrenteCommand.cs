using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class AtualizarContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public AtualizarContaCorrenteCommand(
            Guid id,
            string numeroDaContaCorrente,
            Guid agenciaId,
            Guid clienteId)
        {
            Id = id;
            NumeroDaContaCorrente = numeroDaContaCorrente;
            AgenciaId = agenciaId;
            ClienteId = clienteId;
        }
    }
}
