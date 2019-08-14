using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class LancamentoContaCorrenteAtualizadoEvent : BaseLancamentoContaCorrenteEvent
    {
        public LancamentoContaCorrenteAtualizadoEvent(
                    Guid id,
                    int sequencial,
                    string observacao,
                    decimal valor,
                    DateTime dataDoLancamento,
                    int competencia,
                    DateTime dataDeCadastro)
        {
            Id = id;
            Sequencial = sequencial;
            Observacao = observacao;
            Valor = valor;
            DataDoLancamento = dataDoLancamento;
            Competencia = competencia;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
