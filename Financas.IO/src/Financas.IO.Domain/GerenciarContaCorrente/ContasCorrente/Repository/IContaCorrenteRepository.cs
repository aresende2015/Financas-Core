using Financas.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Repository
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        Cliente ObterClientePorId(Guid clienteId);

        IEnumerable<Cliente> ObterTodosCliente();

        void AdicionarCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);

        void ExcluirCliente(Guid clienteId);

        IEnumerable<Cliente> BuscarCliente(Expression<Func<Cliente, bool>> predicate);

        Lancamento ObterLancamentoPorId(Guid lancamentoId);

        IEnumerable<Lancamento> ObterTodosLancamentoPorContaCorrente(Guid contaCorrenteId);

        void AdicionarLancamento(Lancamento lancamento);

        void AtualizarLancamento(Lancamento lancamento);

        void ExcluirLancamento(Guid lancamentoId);

        CentroDeCusto ObterCentroDeCustoPorId(Guid centroDeCustoId);

        IEnumerable<CentroDeCusto> ObterTodosCentroDeCusto();

        void AdicionarCentroDeCusto(CentroDeCusto centroDeCusto);

        void AtualizarCentroDeCusto(CentroDeCusto centroDeCusto);

        void ExcluirCentroDeCusto(Guid centroDeCustoId);
    }
}
