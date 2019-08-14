using System;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Repository;
using Financas.IO.Infra.Data2.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Financas.IO.Infra.Data2.Repository.GerenciarClientes.ContasCorrente
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(FinancaEFContext context) : base(context)
        {

        }

        public override ContaCorrente ObterPorId(Guid id)
        {
            return Db.ContasCorrentes
                .Include(cc => cc.Cliente)
                .Include(cc => cc.Agencia)
                .FirstOrDefault(cc => cc.Id == id);
        }

        #region Cliente
        public void AdicionarCliente(Cliente cliente)
        {
            Db.Clientes.Add(cliente);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            Db.Clientes.Update(cliente);
        }

        public void ExcluirCliente(Guid clienteId)
        {
            Db.Clientes.Remove(Db.Clientes.Find(clienteId));
        }

        public Cliente ObterClientePorId(Guid clienteId)
        {
            return Db.Clientes.Find(clienteId);
        }

        public IEnumerable<Cliente> ObterTodosCliente()
        {
            return Db.Clientes.ToList();
        }

        public IEnumerable<Cliente> BuscarCliente(Expression<Func<Cliente, bool>> predicate)
        {
            return Db.Clientes.AsNoTracking().Where(predicate);
        }
        #endregion

        #region Lancamento
        public void AdicionarLancamento(Lancamento lancamento)
        {
            Db.Lancamentos.Add(lancamento);
        }

        public void AtualizarLancamento(Lancamento lancamento)
        {
            Db.Lancamentos.Update(lancamento);
        }

        public void ExcluirLancamento(Guid lancamentoId)
        {
            Db.Lancamentos.Remove(Db.Lancamentos.Find(lancamentoId));
        }

        public Lancamento ObterLancamentoPorId(Guid lancamentoId)
        {
            return Db.Lancamentos.Find(lancamentoId);
        }

        public IEnumerable<Lancamento> ObterTodosLancamentoPorContaCorrente(Guid contaCorrenteId)
        {
            return Db.Lancamentos.Where(l => l.ContaCorrenteId == contaCorrenteId);
        }
        #endregion

        #region CentroDeCusto
        public void AdicionarCentroDeCusto(CentroDeCusto centroDeCusto)
        {
            Db.CentroDeCustos.Add(centroDeCusto);
        }

        public void AtualizarCentroDeCusto(CentroDeCusto centroDeCusto)
        {
            Db.CentroDeCustos.Update(centroDeCusto);
        }

        public void ExcluirCentroDeCusto(Guid centroDeCustoId)
        {
            Db.CentroDeCustos.Remove(Db.CentroDeCustos.Find(centroDeCustoId));
        }

        public CentroDeCusto ObterCentroDeCustoPorId(Guid centroDeCustoId)
        {
            return Db.CentroDeCustos.Find(centroDeCustoId);
        }

        public IEnumerable<CentroDeCusto> ObterTodosCentroDeCusto()
        {
            return Db.CentroDeCustos.ToList();
        }

        #endregion
    }
}
