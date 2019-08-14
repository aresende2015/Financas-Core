using Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Aplication.Interfaces.GerenciarContaCorrente.ContasCorrente
{
    public interface IContaCorrenteAppService : IDisposable
    {
        ContaCorrenteViewModel ObterPorId(Guid id);

        IEnumerable<ContaCorrenteViewModel> ObterTodos();

        void Cadastrar(ContaCorrenteViewModel contaCorrenteViewModel);

        void Atualizar(ContaCorrenteViewModel contaCorrenteViewModel);

        void Excluir(Guid id);

        CentroDeCustoViewModel ObterCentroDeCustoPorId(Guid centroDeCustoId);

        IEnumerable<CentroDeCustoViewModel> ObterTodosCentroDeCusto();

        void CadastrarCentroDeCusto(CentroDeCustoViewModel centroDeCustoViewModel);

        void AtualizarCentroDeCusto(CentroDeCustoViewModel centroDeCustoViewModel);

        void ExcluirCentroDeCusto(Guid centroDeCustoId);

        ClienteViewModel ObterClientePorId(Guid clienteId);

        IEnumerable<ClienteViewModel> ObterTodosCliente();

        void CadastrarCliente(ClienteViewModel clienteViewModel);

        void AtualizarCliente(ClienteViewModel clienteViewModel);

        void ExcluirCliente(Guid clienteId);

        LancamentoViewModel ObterLancamentoPorId(Guid lancamentoId);

        IEnumerable<LancamentoViewModel> ObterTodosLancamentosPorContaCorrente(Guid contaCorrenteId);

        void CadastrarLancamento(LancamentoViewModel lancamentoViewModel);

        void AtualizarLancamento(LancamentoViewModel lancamentoViewModel);

        void ExcluirLancamento(Guid lancamentoId);
    }
}
