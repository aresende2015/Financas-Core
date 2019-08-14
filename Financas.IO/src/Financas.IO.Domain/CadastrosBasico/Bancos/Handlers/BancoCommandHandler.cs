using Financas.IO.Domain.CadastrosBasico.Bancos.Commands;
using Financas.IO.Domain.CadastrosBasico.Bancos.Events;
using Financas.IO.Domain.CadastrosBasico.Bancos.Repository;
using Financas.IO.Domain.CommandHandlers;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Handlers
{
    public class BancoCommandHandler : CommandHandler,
        IHandler<CadastrarBancoCommand>,
        IHandler<AtualizarBancoCommand>,
        IHandler<ExcluirBancoCommand>
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IBus _bus;

        public BancoCommandHandler(IBancoRepository bancoRepository,
                                   IUnitOfWork uow,
                                   IBus bus,
                                   IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bancoRepository = bancoRepository;
            _bus = bus;
        }

        public void Handle(CadastrarBancoCommand message)
        {

            var banco = Banco.BancoFactory.NovoBancoCompleto(message.Id, message.Descricao, 
                            message.DataDeCadastro, message.Ativo);

            if (!BancoValido(banco)) return;

            // TODO:
            // Validações de negócio!

            _bancoRepository.Adicionar(banco);

            if (Commit())
            {
                Console.WriteLine("Evento registrado com sucesso");
                _bus.RaiseEvent(new BancoCadastradoEvent(banco.Id, banco.Descricao, banco.DataDeCadastro));
            }
        }

        public void Handle(AtualizarBancoCommand message)
        {
            var bancoAtual = _bancoRepository.ObterPorId(message.Id);

            if (!BancoExistente(message.Id, message.MessageType)) return;

            // A data de cadastro e o indicador de ativo não são atualizados, são mantidos do dado atual
            var banco = Banco.BancoFactory.NovoBancoCompleto(message.Id, message.Descricao, 
                            bancoAtual.DataDeCadastro, bancoAtual.Ativo);

            if (!BancoValido(banco)) return;

            _bancoRepository.Atualizar(banco);

            if (Commit())
            {
                _bus.RaiseEvent(new BancoAtualizadoEvent(banco.Id, banco.Descricao));
            }
        }

        public void Handle(ExcluirBancoCommand message)
        {
            if (!BancoExistente(message.Id, message.MessageType)) return;

            _bancoRepository.Excluir(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new BancoExcluidoEvent(message.Id));
            }
        }

        private bool BancoValido(Banco banco)
        {
            if (banco.EhValido()) return true;

            NotificarValidacoesErro(banco.ValidationResult);
            return false;
        }

        private bool BancoExistente(Guid id, string messageType)
        {
            var banco = _bancoRepository.ObterPorId(id);

            if (banco != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Banco não encontrada."));
            return false;
        }
    }
}
