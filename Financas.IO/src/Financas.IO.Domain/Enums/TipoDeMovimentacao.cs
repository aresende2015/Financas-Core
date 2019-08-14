using System.ComponentModel;

namespace Financas.IO.Domain.Enums
{
    public enum TipoDeMovimentacao
    {
        [Description("Receita")]
        RECEITA = 1,
        [Description("Despesa")]
        DESPESA = 2,
        [Description("Movimentação Financeira")]
        MOVIMENTACAOFINANCEIRA = 3
    }
}
