using Financas.IO.Domain.AgenCadastrosBasico.Agenciascias.Events;
using Financas.IO.Domain.CadastrosBasico.Agencias.Commands;
using Financas.IO.Domain.CadastrosBasico.Agencias.Events;
using Financas.IO.Domain.CadastrosBasico.Agencias.Repository;
using Financas.IO.Domain.CommandHandlers;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Handlers
{
    public class AgenciaCommandHandler : CommandHandler,
        IHandler<CadastrarAgenciaCommand>,
        IHandler<AtualizarAgenciaCommand>,
        IHandler<ExcluirAgenciaCommand>,
        IHandler<IncluirEnderecoAgenciaCommand>,
        IHandler<AtualizarEnderecoAgenciaCommand>
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly IBus _bus;

        public AgenciaCommandHandler(IAgenciaRepository agenciaRepository,
                                     IUnitOfWork uow,
                                     IBus bus,
                                     IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _agenciaRepository = agenciaRepository;
            _bus = bus;
        }

        public void Handle(CadastrarAgenciaCommand message)
        {
            var endereco = new Endereco(message.Endereco.Id, message.Endereco.Logradouro, message.Endereco.Numero,
                message.Endereco.Complemento, message.Endereco.Bairro, message.Endereco.CEP, message.Endereco.DataDeCadastro,
                message.Endereco.Ativo, message.Endereco.CidadeId, message.Id);

            var agencia = Agencia.AgenciaFactory.NovaAgenciaCompleta(message.Id, message.NumeroDaAgencia,
                message.NomeDaAgencia, message.DataDeCadastro, message.Ativo, endereco, message.BancoId);

            if (!AgenciaValida(agencia)) return;

            // TODO:
            // Validações de negócio!

            if (!AgenciaExistente(message.NumeroDaAgencia, message.MessageType)) return;

            if (!AgenciaExistente(message.NomeDaAgencia, message.MessageType)) return;

            _agenciaRepository.Adicionar(agencia);

            if (Commit())
            {
                Console.WriteLine("Evento registrado com sucesso");
                _bus.RaiseEvent(new AgenciaCadastradaEvent(agencia.Id, agencia.NumeroDaAgencia, agencia.NomeDaAgencia, agencia.DataDeCadastro));
            }
        }

        public void Handle(AtualizarAgenciaCommand message)
        {
            var agenciaAtual = _agenciaRepository.ObterPorId(message.Id);

            if (!AgenciaExistente(message.Id, message.MessageType)) return;

            var agencia = Agencia.AgenciaFactory.NovaAgenciaCompleta(message.Id, message.NumeroDaAgencia,
                message.NomeDaAgencia, agenciaAtual.DataDeCadastro, agenciaAtual.Ativo, agenciaAtual.Endereco, message.BancoId);

            if (!AgenciaValida(agencia)) return;

            _agenciaRepository.Atualizar(agencia);

            if (Commit())
            {
                _bus.RaiseEvent(new AgenciaAtualizadaEvent(agencia.Id, agencia.NumeroDaAgencia, agencia.NomeDaAgencia));
            }
        }

        public void Handle(ExcluirAgenciaCommand message)
        {
            if (!AgenciaExistente(message.Id, message.MessageType)) return;

            _agenciaRepository.Excluir(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new AgenciaExcluidaEvent(message.Id));
            }
        }

        private bool AgenciaValida(Agencia agencia)
        {
            if (agencia.EhValido()) return true;

            NotificarValidacoesErro(agencia.ValidationResult);
            return false;
        }

        private bool AgenciaExistente(Guid id, string messageType)
        {
            var agencia = _agenciaRepository.ObterPorId(id);

            if (agencia != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Agência não encontrada."));
            return false;
        }

        private bool AgenciaExistente(int numeroDaAgencia, string messageType)
        {
            var agencia = _agenciaRepository.ObterAgenciaPorNumero(numeroDaAgencia);

            if (agencia == null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Número da agência já existente."));
            return false;
        }

        private bool AgenciaExistente(string nomeDaAgencia, string messageType)
        {
            var agencia = _agenciaRepository.ObterAgenciaPorNome(nomeDaAgencia);

            if (agencia == null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Nome da agência já existente."));
            return false;
        }

        public void Handle(IncluirEnderecoAgenciaCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero, 
                                        message.Complemento, message.Bairro, message.CEP, 
                                        message.DataDeCadastro, message.Ativo, 
                                        message.CidadeId, message.AgenciaId.Value);

            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _agenciaRepository.AdicionarEnderco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoAgenciaIncluidoEvent(
                                        endereco.Id, endereco.Logradouro, endereco.Numero, 
                                        endereco.Complemento, endereco.Bairro, endereco.CEP, 
                                        endereco.CidadeId, endereco.DataDeCadastro, endereco.Ativo, 
                                        endereco.AgenciaId.Value));
            }
        }

        public void Handle(AtualizarEnderecoAgenciaCommand message)
        {
            var endereco = new Endereco(message.Id, message.Logradouro, message.Numero,
                                        message.Complemento, message.Bairro, message.CEP,
                                        message.DataDeCadastro, message.Ativo,
                                        message.CidadeId, message.AgenciaId.Value);

            if (!endereco.EhValido())
            {
                NotificarValidacoesErro(endereco.ValidationResult);
                return;
            }

            _agenciaRepository.AtualizarEnderco(endereco);

            if (Commit())
            {
                _bus.RaiseEvent(new EnderecoAgenciaAtualizadoEvent(
                                        endereco.Id, endereco.Logradouro, endereco.Numero,
                                        endereco.Complemento, endereco.Bairro, endereco.CEP,
                                        endereco.CidadeId, endereco.DataDeCadastro, endereco.Ativo,
                                        endereco.AgenciaId.Value));
            }
        }
    }
}
