using AutoMapper;
using Financas.IO.Aplication.Interfaces.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Repository;
using System;
using System.Collections.Generic;

namespace Financas.IO.Aplication.Services.GerenciarContaCorrente.ContasCorrente
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteAppService(IBus bus, IMapper mapper, IContaCorrenteRepository contaCorrenteRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        #region ContaCorrente

        public void Cadastrar(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var cadastrarContaCorrenteCommand = _mapper.Map<CadastrarContaCorrenteCommand>(contaCorrenteViewModel);
            _bus.SendCommand(cadastrarContaCorrenteCommand);
        }

        public void Atualizar(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var atualizarContaCorrenteCommand = _mapper.Map<AtualizarContaCorrenteCommand>(contaCorrenteViewModel);
            _bus.SendCommand(atualizarContaCorrenteCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirContaCorrenteCommand(id));
        }

        public ContaCorrenteViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ContaCorrenteViewModel>(_contaCorrenteRepository.ObterPorId(id));
        }

        public IEnumerable<ContaCorrenteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(_contaCorrenteRepository.ObterTodos());
        }

        #endregion

        #region CentroDeCusto

        public void CadastrarCentroDeCusto(CentroDeCustoViewModel centroDeCustoViewModel)
        {
            var cadastrarCentroDeCustoContaCorrenteCommand = _mapper.Map<CadastrarCentroDeCustoContaCorrenteCommand>(centroDeCustoViewModel);
            _bus.SendCommand(cadastrarCentroDeCustoContaCorrenteCommand);
        }

        public void AtualizarCentroDeCusto(CentroDeCustoViewModel centroDeCustoViewModel)
        {
            var atualizarCentroDeCustoContaCorrenteCommand = _mapper.Map<AtualizarCentroDeCustoContaCorrenteCommand>(centroDeCustoViewModel);
            _bus.SendCommand(atualizarCentroDeCustoContaCorrenteCommand);
        }

        public void ExcluirCentroDeCusto(Guid centroDeCustoId)
        {
            _bus.SendCommand(new ExcluirCentroDeCustoContaCorrenteCommand(centroDeCustoId));
        }

        public CentroDeCustoViewModel ObterCentroDeCustoPorId(Guid centroDeCustoId)
        {
            return _mapper.Map<CentroDeCustoViewModel>(_contaCorrenteRepository.ObterCentroDeCustoPorId(centroDeCustoId));
        }

        public IEnumerable<CentroDeCustoViewModel> ObterTodosCentroDeCusto()
        {
            return _mapper.Map<IEnumerable<CentroDeCustoViewModel>>(_contaCorrenteRepository.ObterTodosCentroDeCusto());
        }

        #endregion

        #region Cliente

        public void CadastrarCliente(ClienteViewModel clienteViewModel)
        {
            var cadastrarClienteContaCorrenteCommand = _mapper.Map<CadastrarClienteContaCorrenteCommand>(clienteViewModel);
            _bus.SendCommand(cadastrarClienteContaCorrenteCommand);
        }

        public void AtualizarCliente(ClienteViewModel clienteViewModel)
        {
            var atualizarClienteContaCorrenteCommand = _mapper.Map<AtualizarClienteContaCorrenteCommand>(clienteViewModel);
            _bus.SendCommand(atualizarClienteContaCorrenteCommand);
        }

        public void ExcluirCliente(Guid clienteId)
        {
            _bus.SendCommand(new ExcluirClienteContaCorrenteCommand(clienteId));
        }

        public ClienteViewModel ObterClientePorId(Guid clienteId)
        {
            return _mapper.Map<ClienteViewModel>(_contaCorrenteRepository.ObterClientePorId(clienteId));
        }

        public IEnumerable<ClienteViewModel> ObterTodosCliente()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_contaCorrenteRepository.ObterTodosCliente());
        }

        #endregion

        #region Lancamento

        public void CadastrarLancamento(LancamentoViewModel lancamentoViewModel)
        {
            var cadastrarLancamentoContaCorrenteCommand = _mapper.Map<CadastrarLancamentoContaCorrenteCommand>(lancamentoViewModel);
            _bus.SendCommand(cadastrarLancamentoContaCorrenteCommand);
        }

        public void AtualizarLancamento(LancamentoViewModel lancamentoViewModel)
        {
            var atualizarLancamentoContaCorrenteCommand = _mapper.Map<AtualizarLancamentoContaCorrenteCommand>(lancamentoViewModel);
            _bus.SendCommand(atualizarLancamentoContaCorrenteCommand);
        }

        public void ExcluirLancamento(Guid lancamentoId)
        {
            _bus.SendCommand(new ExcluirLancamentoContaCorrenteCommand(lancamentoId));
        }

        public LancamentoViewModel ObterLancamentoPorId(Guid lancamentoId)
        {
            return _mapper.Map<LancamentoViewModel>(_contaCorrenteRepository.ObterLancamentoPorId(lancamentoId));
        }

        public IEnumerable<LancamentoViewModel> ObterTodosLancamentosPorContaCorrente(Guid contaCorrenteId)
        {
            return _mapper.Map<IEnumerable<LancamentoViewModel>>(_contaCorrenteRepository.ObterTodosLancamentoPorContaCorrente(contaCorrenteId));
        }

        #endregion

        public void Dispose()
        {
            _contaCorrenteRepository.Dispose();
        }

    }
}
