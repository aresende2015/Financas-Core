using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class AtualizarCentroDeCustoContaCorrenteCommand :BaseCentroDeCustoContaCorrenteCommand
    {
        public AtualizarCentroDeCustoContaCorrenteCommand(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
