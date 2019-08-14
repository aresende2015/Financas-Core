using AutoMapper;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.PlanosDeContas;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Repositoy;
using Financas.IO.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Aplication.Services.CadastrosBasico.PlanosDeContas
{
    public class PlanoDeContaAppService : IPlanoDeContaAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IPlanoDeContaRepository _planoDeContaRepository;

        public PlanoDeContaAppService(IBus bus, IMapper mapper, IPlanoDeContaRepository planoDeContaRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _planoDeContaRepository = planoDeContaRepository;
        }

        #region PlanoDeConta
        public PlanoDeContaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<PlanoDeContaViewModel>(_planoDeContaRepository.ObterPorId(id));
        }

        public IEnumerable<PlanoDeContaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PlanoDeContaViewModel>>(_planoDeContaRepository.ObterTodos());
        }

        public void Cadastrar(PlanoDeContaViewModel planoDeContaViewModel)
        {
            var cadastrarPlanoDeContaCommand = _mapper.Map<CadastrarPlanoDeContaCommand>(planoDeContaViewModel);
            _bus.SendCommand(cadastrarPlanoDeContaCommand);
        }

        public void Atualizar(PlanoDeContaViewModel planoDeContaViewModel)
        {
            var atualizarPlanoDeContaCommand = _mapper.Map<AtualizarPlanoDeContaCommand>(planoDeContaViewModel);
            _bus.SendCommand(atualizarPlanoDeContaCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirPlanoDeContaCommand(id));
        }

        public IEnumerable<PlanoDeContaViewModel> ObterPlanoDecontaPorGrupoDeConta(Guid GrupoDeContaId)
        {
            return _mapper.Map<IEnumerable<PlanoDeContaViewModel>>(_planoDeContaRepository.ObterPlanoDecontaPorGrupoDeConta(GrupoDeContaId));
        }
        #endregion

        #region GrupoDeConta
        public GrupoDeContaViewModel ObterGrupoDeContaPorId(Guid grupoDeContaId)
        {
            return _mapper.Map<GrupoDeContaViewModel>(_planoDeContaRepository.ObterGrupoDeContaPorId(grupoDeContaId));
        }

        public IEnumerable<GrupoDeContaViewModel> ObterTodosGrupoDeConta()
        {
            return _mapper.Map<IEnumerable<GrupoDeContaViewModel>>(_planoDeContaRepository.ObterTodosGrupoDeConta());
        }

        public void CadastrarGrupoDeConta(GrupoDeContaViewModel grupoDeContaViewModel)
        {
            var cadastrarGrupoDeContaPlanoDeContaCommand = _mapper.Map<CadastrarGrupoDeContaPlanoDeContaCommand>(grupoDeContaViewModel);
            _bus.SendCommand(cadastrarGrupoDeContaPlanoDeContaCommand);
        }

        public void AtualizarGrupoDeConta(GrupoDeContaViewModel grupoDeContaViewModel)
        {
            var atualizarGrupoDeContaPlanoDeContaCommand = _mapper.Map<AtualizarGrupoDeContaPlanoDeContaCommand>(grupoDeContaViewModel);
            _bus.SendCommand(atualizarGrupoDeContaPlanoDeContaCommand);
        }

        public void ExcluirGrupoDeConta(Guid grupoDeContaId)
        {
            _bus.SendCommand(new ExcluirGrupoDeContaPlanoDeContaCommand(grupoDeContaId));
        }

        #endregion

        public void Dispose()
        {
            _planoDeContaRepository.Dispose();
        }
    }
}
