using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class AtualizarLancamentoContaCorrenteCommand : BaseLancamentoContaCorrenteCommand
    {
        public AtualizarLancamentoContaCorrenteCommand(
                    Guid id,
                    int sequencial,
                    string observacao,
                    decimal valor,
                    DateTime dataDoLancamento,
                    int competencia,
                    Guid centroDeCustoId,
                    Guid planoDeContaId,
                    Guid contaCorrenteId)
        {
            Id = id;
            Sequencial = sequencial;
            Observacao = observacao;
            Valor = valor;
            DataDoLancamento = dataDoLancamento;
            Competencia = competencia;
            CentroDeCustoId = centroDeCustoId;
            PlanoDeContaId = planoDeContaId;
            ContaCorrenteId = contaCorrenteId;
        }
    }
}
