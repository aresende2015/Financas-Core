using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class BaseLancamentoContaCorrenteEvent : Event
    {
        public Guid Id { get; protected set; }

        public int Sequencial { get; protected set; }

        public string Observacao { get; protected set; }

        public decimal Valor { get; protected set; }

        public DateTime DataDoLancamento { get; protected set; }

        public int Competencia { get; protected set; }

        public Guid CentroDeCustoId { get; protected set; }

        public Guid PlanoDeContaId { get; protected set; }

        public Guid ContaCorrenteId { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
