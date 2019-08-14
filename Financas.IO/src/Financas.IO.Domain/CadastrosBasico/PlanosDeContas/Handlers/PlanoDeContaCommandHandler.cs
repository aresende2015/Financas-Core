using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Repositoy;
using Financas.IO.Domain.CommandHandlers;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Handlers
{
    public class PlanoDeContaCommandHandler : CommandHandler,
        IHandler<CadastrarPlanoDeContaCommand>,
        IHandler<AtualizarPlanoDeContaCommand>,
        IHandler<ExcluirPlanoDeContaCommand>,
        IHandler<CadastrarGrupoDeContaPlanoDeContaCommand>,
        IHandler<AtualizarGrupoDeContaPlanoDeContaCommand>,
        IHandler<ExcluirGrupoDeContaPlanoDeContaCommand>
    {
        private readonly IPlanoDeContaRepository _planoDeContaRepository;
        private readonly IBus _bus;

        public PlanoDeContaCommandHandler(IPlanoDeContaRepository planoDeContaRepository,
                                          IUnitOfWork uow,
                                          IBus bus,
                                          IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _planoDeContaRepository = planoDeContaRepository;
            _bus = bus;
        }

        #region PlanoDeConta
        public void Handle(CadastrarPlanoDeContaCommand message)
        {
            var planoDeConta = PlanoDeConta.PlanoDeContaFactory.NovoPlanoDeContaCompleto(
                                    message.Id, message.Descricao, message.TipoDeMovimento,
                                    message.GrupoDeContaId, message.DataDeCadastro, message.Ativo);

            if (!PlanoDeContaValido(planoDeConta)) return;

            // TODO:
            // Validações de negócio!

            _planoDeContaRepository.Adicionar(planoDeConta);

            if (Commit())
            {
                Console.WriteLine("Plano de conta registrado com sucesso");
                _bus.RaiseEvent(new PlanoDeContaCadastradoEvent(
                                    planoDeConta.Id, planoDeConta.Descricao, planoDeConta.TipoDeMovimento, 
                                    planoDeConta.DataDeCadastro));
            }
        }

        public void Handle(AtualizarPlanoDeContaCommand message)
        {
            var planoDeContaAtual = _planoDeContaRepository.ObterPorId(message.Id);

            if (!PlanoDeContaExistente(message.Id, message.MessageType)) return;

            var planoDeConta = PlanoDeConta.PlanoDeContaFactory.NovoPlanoDeContaCompleto(
                                message.Id, message.Descricao, message.TipoDeMovimento, message.GrupoDeContaId, 
                                planoDeContaAtual.DataDeCadastro, planoDeContaAtual.Ativo);

            if (!PlanoDeContaValido(planoDeConta)) return;

            _planoDeContaRepository.Atualizar(planoDeConta);

            if (Commit())
            {
                Console.WriteLine("Plano de conta atualizado com sucesso");
                _bus.RaiseEvent(new PlanoDeContaAtualizadoEvent(planoDeConta.Id,planoDeConta.Descricao,
                                    planoDeConta.TipoDeMovimento,planoDeConta.DataDeCadastro));
            }

        }

        public void Handle(ExcluirPlanoDeContaCommand message)
        {
            if (!PlanoDeContaExistente(message.Id, message.MessageType)) return;

            var planoDeContaAtual = _planoDeContaRepository.ObterPorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            planoDeContaAtual.ExcluirPlanoDeConta();

            _planoDeContaRepository.Atualizar(planoDeContaAtual);

            if (Commit())
            {
                Console.WriteLine("Plano de conta excluído com sucesso");
                _bus.RaiseEvent(new PlanoDeContaExcluidoEvent(message.Id));
            }
        }

        private bool PlanoDeContaValido(PlanoDeConta planoDeConta)
        {
            if (planoDeConta.EhValido()) return true;

            NotificarValidacoesErro(planoDeConta.ValidationResult);
            return false;
        }

        private bool PlanoDeContaExistente(Guid id, string messageType)
        {
            var planoDeConta = _planoDeContaRepository.ObterPorId(id);

            if (planoDeConta != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Plano de conta não encontrado"));
            return false;
        }
        #endregion

        #region GrupoDeConta
        public void Handle(CadastrarGrupoDeContaPlanoDeContaCommand message)
        {
            var grupoDeConta = GrupoDeConta.GrupoDeContaFactory.NovoGrupoDeContaCompleto(
                                message.Id, message.Descricao, message.DataDeCadastro, message.Ativo);

            if (!GrupoDeContaValido(grupoDeConta)) return;

            // TODO:
            // Validações de negócio!

            _planoDeContaRepository.AdicionarGrupoDeConta(grupoDeConta);

            if (Commit())
            {
                Console.WriteLine("Grupo de conta registrado com sucesso");
                _bus.RaiseEvent(new GrupoDeContaPlanoDeContaCadastradoEvent(
                                        grupoDeConta.Id, grupoDeConta.Descricao, grupoDeConta.DataDeCadastro));
            }
        }

        public void Handle(AtualizarGrupoDeContaPlanoDeContaCommand message)
        {
            var grupoDeContaAtual = _planoDeContaRepository.ObterGrupoDeContaPorId(message.Id);

            if (!GrupoDeContaExistente(message.Id, message.MessageType)) return;

            var grupoDeConta = GrupoDeConta.GrupoDeContaFactory.NovoGrupoDeContaCompleto(
                                            message.Id, message.Descricao,
                                            grupoDeContaAtual.DataDeCadastro, grupoDeContaAtual.Ativo);

            if (!GrupoDeContaValido(grupoDeConta)) return;

            if (Commit())
            {
                Console.WriteLine("Grupo de conta atualizado com sucesso");
                _bus.RaiseEvent(new GrupoDeContaPlanoDeContaAtualizadoEvent(
                                        grupoDeConta.Id, grupoDeConta.Descricao, grupoDeConta.DataDeCadastro));
            }
        }

        public void Handle(ExcluirGrupoDeContaPlanoDeContaCommand message)
        {
            if (!GrupoDeContaExistente(message.Id, message.MessageType)) return;

            var grupoDeContaAtual = _planoDeContaRepository.ObterGrupoDeContaPorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            grupoDeContaAtual.ExcluirGrupoDeConta();

            _planoDeContaRepository.AtualizarGrupoDeConta(grupoDeContaAtual);

            if (Commit())
            {
                Console.WriteLine("Grupo de conta excluído com sucesso");
                _bus.RaiseEvent(new GrupoDeContaPlanoDeContaExcluidoEvent(message.Id));
            }
        }

        private bool GrupoDeContaValido(GrupoDeConta grupoDeConta)
        {
            if (grupoDeConta.EhValido()) return true;

            NotificarValidacoesErro(grupoDeConta.ValidationResult);
            return false;
        }

        private bool GrupoDeContaExistente(Guid id, string messageType)
        {
            var grupoDeConta = _planoDeContaRepository.ObterGrupoDeContaPorId(id);

            if (grupoDeConta != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Grupo de conta não encontrado"));
            return false;
        }
        #endregion
    }
}
