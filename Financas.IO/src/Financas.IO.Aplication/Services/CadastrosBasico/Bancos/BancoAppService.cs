using AutoMapper;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.Bancos;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using Financas.IO.Domain.CadastrosBasico.Bancos.Commands;
using Financas.IO.Domain.CadastrosBasico.Bancos.Repository;
using Financas.IO.Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace Financas.IO.Aplication.Services.CadastrosBasico.Bancos
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IBancoRepository _bancoRepository;

        public BancoAppService(IBus bus, IMapper mapper, IBancoRepository bancoRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _bancoRepository = bancoRepository;
        }

        public BancoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<BancoViewModel>(_bancoRepository.ObterPorId(id));
        }

        public IEnumerable<BancoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<BancoViewModel>>(_bancoRepository.ObterTodos());
        }

        public void Cadastrar(BancoViewModel bancoViewModel)
        {
            var cadastrarBancoCommand = _mapper.Map<CadastrarBancoCommand>(bancoViewModel);
            _bus.SendCommand(cadastrarBancoCommand);
        }

        public void Atualizar(BancoViewModel bancoViewModel)
        {
            var atualizarBancoCommand = _mapper.Map<AtualizarBancoCommand>(bancoViewModel);
            _bus.SendCommand(atualizarBancoCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirBancoCommand(id));
        }

        public void Dispose()
        {
            _bancoRepository.Dispose();
        }

    }
}
