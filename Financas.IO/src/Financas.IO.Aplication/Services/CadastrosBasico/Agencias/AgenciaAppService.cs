using AutoMapper;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.Agencias;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using Financas.IO.Domain.CadastrosBasico.Agencias.Commands;
using Financas.IO.Domain.CadastrosBasico.Agencias.Repository;
using Financas.IO.Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace Financas.IO.Aplication.Services.CadastrosBasico.Agencias
{
    public class AgenciaAppService : IAgenciaAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IAgenciaRepository _agenciaRepository;

        public AgenciaAppService(IBus bus, IMapper mapper, IAgenciaRepository agenciaRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _agenciaRepository = agenciaRepository;
        }

        public AgenciaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<AgenciaViewModel>(_agenciaRepository.ObterPorId(id));
        }

        public IEnumerable<AgenciaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AgenciaViewModel>>(_agenciaRepository.ObterTodos());
        }

        public AgenciaViewModel ObterAgenciaPorNumero(int numeroDaAgencia)
        {
            return _mapper.Map<AgenciaViewModel>(_agenciaRepository.ObterAgenciaPorNumero(numeroDaAgencia));
        }

        public AgenciaViewModel ObterAgenciaPorNome(string nomeDaAgencia)
        {
            return _mapper.Map<AgenciaViewModel>(_agenciaRepository.ObterAgenciaPorNome(nomeDaAgencia));
        }

        public void Cadastrar(AgenciaViewModel agenciaViewModel)
        {
            var cadastrarAgenciaCommand = _mapper.Map<CadastrarAgenciaCommand>(agenciaViewModel);
            _bus.SendCommand(cadastrarAgenciaCommand);
        }

        public void Atualizar(AgenciaViewModel agenciaViewModel)
        {
            var atualizarAgenciaCommand = _mapper.Map<AtualizarAgenciaCommand>(agenciaViewModel);
            _bus.SendCommand(atualizarAgenciaCommand);
        }
                
        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirAgenciaCommand(id));
        }

        public IEnumerable<AgenciaViewModel> ObterAgenciaPorBanco(Guid bancoId)
        {
            return _mapper.Map<IEnumerable<AgenciaViewModel>>(_agenciaRepository.ObterAgenciaPorBanco(bancoId));
        }        
        
        public void Dispose()
        {
            _agenciaRepository.Dispose();
        }

        public IEnumerable<CidadeViewModel> ListarCidadesPorUF(string uf)
        {
            return _mapper.Map<IEnumerable<CidadeViewModel>>(_agenciaRepository.ListarCidadesPorUF(uf));
        }

        public CidadeViewModel ObterCidadePorId(Guid cidadeId)
        {
            return _mapper.Map<CidadeViewModel>(_agenciaRepository.ObterCidadePorId(cidadeId));
        }

        public void IncluirEndereco(EnderecoViewModel enderecoViewModel)
        {
            var incluirEnderecoAgenciaCommand = _mapper.Map<IncluirEnderecoAgenciaCommand>(enderecoViewModel);
            _bus.SendCommand(incluirEnderecoAgenciaCommand);
        }

        public void AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var atualizarEnderecoAgenciaCommand = _mapper.Map<AtualizarEnderecoAgenciaCommand>(enderecoViewModel);
            _bus.SendCommand(atualizarEnderecoAgenciaCommand);
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_agenciaRepository.ObterEnderecoPorId(id));
        }

    }
}
