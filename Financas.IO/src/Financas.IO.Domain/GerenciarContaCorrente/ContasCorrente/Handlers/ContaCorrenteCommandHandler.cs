using Financas.IO.Domain.CommandHandlers;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Repository;
using Financas.IO.Domain.Interfaces;
using System;
using System.Linq;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Handlers
{
    public class ContaCorrenteCommandHandler : CommandHandler,
        IHandler<CadastrarContaCorrenteCommand>,
        IHandler<AtualizarContaCorrenteCommand>,
        IHandler<ExcluirContaCorrenteCommand>,
        IHandler<CadastrarClienteContaCorrenteCommand>,
        IHandler<AtualizarClienteContaCorrenteCommand>,
        IHandler<ExcluirClienteContaCorrenteCommand>,
        IHandler<CadastrarLancamentoContaCorrenteCommand>,
        IHandler<AtualizarLancamentoContaCorrenteCommand>,
        IHandler<ExcluirLancamentoContaCorrenteCommand>,
        IHandler<CadastrarCentroDeCustoContaCorrenteCommand>,
        IHandler<AtualizarCentroDeCustoContaCorrenteCommand>,
        IHandler<ExcluirCentroDeCustoContaCorrenteCommand>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IBus _bus;

        public ContaCorrenteCommandHandler(IContaCorrenteRepository contaCorrenteRepository,
                                           IUnitOfWork uow,
                                           IBus bus,
                                           IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _bus = bus;
        }

        #region Handler ContaCorrente
        public void Handle(CadastrarContaCorrenteCommand message)
        {
            var contaCorrente = ContaCorrente.ContaCorrenteFactory.NovaContaCorrenteCompleta(
                                    message.Id, message.NumeroDaContaCorrente, message.DataDeCadastro,
                                    message.Ativo, message.AgenciaId, message.ClienteId);

            if (!ContaCorrenteValida(contaCorrente)) return;

            // TODO:
            // Validações de negócio!

            _contaCorrenteRepository.Adicionar(contaCorrente);

            if (Commit())
            {
                Console.WriteLine("Conta corrente registrada com sucesso");
                _bus.RaiseEvent(new ContaCorrenteCadastradaEvent(contaCorrente.Id, contaCorrente.NumeroDaContaCorrente, contaCorrente.DataDeCadastro));
            }
        }

        public void Handle(AtualizarContaCorrenteCommand message)
        {
            var contaCorrenteAtual = _contaCorrenteRepository.ObterPorId(message.Id);

            if (!ContaCorrenteExistente(message.Id, message.MessageType)) return;

            var contaCorrente = ContaCorrente.ContaCorrenteFactory.NovaContaCorrenteCompleta(
                                    message.Id, message.NumeroDaContaCorrente, contaCorrenteAtual.DataDeCadastro,
                                    contaCorrenteAtual.Ativo, message.AgenciaId, message.ClienteId);

            if (!ContaCorrenteValida(contaCorrente)) return;

            _contaCorrenteRepository.Atualizar(contaCorrente);

            if (Commit())
            {
                Console.WriteLine("Conta corrente atualizada com sucesso");
                _bus.RaiseEvent(new ContaCorrenteAtualizadaEvent(contaCorrente.Id, contaCorrente.NumeroDaContaCorrente, contaCorrente.DataDeCadastro));
            }

        }

        public void Handle(ExcluirContaCorrenteCommand message)
        {
            if (!ContaCorrenteExistente(message.Id, message.MessageType)) return;

            var contaCorrenteAtual = _contaCorrenteRepository.ObterPorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            contaCorrenteAtual.ExcluirContaCorrente();

            _contaCorrenteRepository.Atualizar(contaCorrenteAtual);

            if (Commit())
            {
                Console.WriteLine("Conta corrente excluída com sucesso");
                _bus.RaiseEvent(new ContaCorrenteExcluidaEvent(message.Id));
            }


        }

        private bool ContaCorrenteValida(ContaCorrente contaCorrente)
        {
            if (contaCorrente.EhValido()) return true;

            NotificarValidacoesErro(contaCorrente.ValidationResult);
            return false;
        }

        private bool ContaCorrenteExistente(Guid id, string messageType)
        {
            var contaCorrente = _contaCorrenteRepository.ObterPorId(id);

            if (contaCorrente != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Conta corrente não encontrada."));
            return false;
        }
        #endregion

        #region Handler ClienteContaCorrente
        public void Handle(CadastrarClienteContaCorrenteCommand message)
        {
            var cliente = Cliente.ClienteFactory.NovoClienteCompleto(
                                message.Id, message.Nome, message.CPF, message.Email, message.DataDeNascimento,
                                message.DataDeCadastro, message.Ativo);

            if (!ClienteContaCorrenteValido(cliente)) return;

            // TODO:
            // Validações de negócio!

            var clienteExistente = _contaCorrenteRepository.BuscarCliente(c => c.CPF == cliente.CPF || c.Email == cliente.Email);

            if (clienteExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _contaCorrenteRepository.AdicionarCliente(cliente);

            if (Commit())
            {
                Console.WriteLine("Cliente registrado com sucesso");
                _bus.RaiseEvent(new ClienteContaCorrenteCadastradoEvent(
                                        cliente.Id, cliente.Nome, cliente.CPF, cliente.Email,
                                        cliente.DataDeNascimento, cliente.DataDeCadastro));
            }
        }

        public void Handle(AtualizarClienteContaCorrenteCommand message)
        {
            var clienteContaCorrenteAtual = _contaCorrenteRepository.ObterClientePorId(message.Id);

            if (!ClienteContaCorrenteExistente(message.Id, message.MessageType)) return;

            var clienteContaCorrente = Cliente.ClienteFactory.NovoClienteCompleto(
                                            message.Id, message.Nome, message.CPF, message.Email, message.DataDeNascimento,
                                            clienteContaCorrenteAtual.DataDeCadastro, clienteContaCorrenteAtual.Ativo);

            if (!ClienteContaCorrenteValido(clienteContaCorrente)) return;

            if (Commit())
            {
                Console.WriteLine("Cliente atualizado com sucesso");
                _bus.RaiseEvent(new ClienteContaCorrenteAtualizadoEvent(clienteContaCorrente.Id, clienteContaCorrente.Nome, 
                                        clienteContaCorrente.CPF, clienteContaCorrente.Email,
                                        clienteContaCorrente.DataDeNascimento, clienteContaCorrente.DataDeCadastro));
            }
        }

        public void Handle(ExcluirClienteContaCorrenteCommand message)
        {
            if (!ClienteContaCorrenteExistente(message.Id, message.MessageType)) return;

            var clienteContaCorrenteAtual = _contaCorrenteRepository.ObterClientePorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            clienteContaCorrenteAtual.ExcluirCliente();

            _contaCorrenteRepository.AtualizarCliente(clienteContaCorrenteAtual);

            if (Commit())
            {
                Console.WriteLine("Cliente excluído com sucesso");
                _bus.RaiseEvent(new ClienteContaCorrenteExcluidoEvent(message.Id));
            }
        }

        private bool ClienteContaCorrenteValido(Cliente cliente)
        {
            if (cliente.EhValido()) return true;

            NotificarValidacoesErro(cliente.ValidationResult);
            return false;
        }

        private bool ClienteContaCorrenteExistente(Guid id, string messageType)
        {
            var cliente = _contaCorrenteRepository.ObterClientePorId(id);

            if (cliente != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Cliente não encontrada."));
            return false;
        }
        #endregion

        #region Handler LancamentoContaCorrente
        public void Handle(CadastrarLancamentoContaCorrenteCommand message)
        {
            var lancamento = Lancamento.LancamentoFactory.NovoCentroDeCustoCompleto(
                                    message.Id, message.Sequencial, message.Observacao, message.Valor, message.DataDoLancamento,
                                    message.Competencia, message.CentroDeCustoId, message.PlanoDeContaId, message.ContaCorrenteId,
                                    message.DataDeCadastro, message.Ativo);

            if (!LancamentoContaCorrenteValido(lancamento)) return;

            // TODO:
            // Validações de negócio!

            _contaCorrenteRepository.AdicionarLancamento(lancamento);

            if (Commit())
            {
                Console.WriteLine("Lançamento registrado com sucesso");
                _bus.RaiseEvent(new LancamentoContaCorrenteCadastradoEvent(
                                        lancamento.Id, lancamento.Sequencial, lancamento.Observacao, lancamento.Valor,
                                        lancamento.DataDoLancamento, lancamento.Competencia, lancamento.DataDeCadastro));
            }
        }

        public void Handle(AtualizarLancamentoContaCorrenteCommand message)
        {
            var lancamentoContaCorrenteAtual = _contaCorrenteRepository.ObterLancamentoPorId(message.Id);

            if (!LancamentoContaCorrenteExistente(message.Id, message.MessageType)) return;

            var lancamentoContaCorrente = Lancamento.LancamentoFactory.NovoCentroDeCustoCompleto(
                                                message.Id, message.Sequencial, message.Observacao, message.Valor,
                                                message.DataDoLancamento, message.Competencia, message.CentroDeCustoId,
                                                message.PlanoDeContaId, message.ContaCorrenteId,
                                                lancamentoContaCorrenteAtual.DataDeCadastro, lancamentoContaCorrenteAtual.Ativo);

            if (!LancamentoContaCorrenteValido(lancamentoContaCorrente)) return;

            if (Commit())
            {
                Console.WriteLine("Lançamento atualizado com sucesso");
                _bus.RaiseEvent(new LancamentoContaCorrenteAtualizadoEvent(
                                        lancamentoContaCorrente.Id, lancamentoContaCorrente.Sequencial, lancamentoContaCorrente.Observacao,
                                        lancamentoContaCorrente.Valor, lancamentoContaCorrente.DataDoLancamento,
                                        lancamentoContaCorrente.Competencia, lancamentoContaCorrente.DataDeCadastro));
            }
        }

        public void Handle(ExcluirLancamentoContaCorrenteCommand message)
        {
            if (!LancamentoContaCorrenteExistente(message.Id, message.MessageType)) return;

            var lancamentoContaCorrenteAtual = _contaCorrenteRepository.ObterLancamentoPorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            lancamentoContaCorrenteAtual.ExcluirLancamento();

            _contaCorrenteRepository.AtualizarLancamento(lancamentoContaCorrenteAtual);

            if (Commit())
            {
                Console.WriteLine("Lançamento excluído com sucesso");
                _bus.RaiseEvent(new LancamentoContaCorrenteExcluidoEvent(message.Id));
            }
        }

        private bool LancamentoContaCorrenteValido(Lancamento lancamento)
        {
            if (lancamento.EhValido()) return true;

            NotificarValidacoesErro(lancamento.ValidationResult);
            return false;
        }

        private bool LancamentoContaCorrenteExistente(Guid id, string messageType)
        {
            var lancamento = _contaCorrenteRepository.ObterLancamentoPorId(id);

            if (lancamento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Lancamento não encontrado"));
            return false;
        }
        #endregion

        #region Handler CentroDeCustoContaCorrente
        public void Handle(CadastrarCentroDeCustoContaCorrenteCommand message)
        {
            var centroDeCusto = CentroDeCusto.CentroDeCustoFactory.NovoCentroDeCustoCompleto(
                                        message.Id, message.Descricao, message.DataDeCadastro, message.Ativo);

            if (!CentroDeCustoContaCorrenteValido(centroDeCusto)) return;

            // TODO:
            // Validações de negócio!

            _contaCorrenteRepository.AdicionarCentroDeCusto(centroDeCusto);

            if (Commit())
            {
                Console.WriteLine("Centro de custo registrado com sucesso");
                _bus.RaiseEvent(new CentroDeCustoContaCorrenteCadastradoEvent(message.Id, message.Descricao, message.DataDeCadastro));
            }
        }

        public void Handle(AtualizarCentroDeCustoContaCorrenteCommand message)
        {
            var centroDeCustoContaCorrenteAtual = _contaCorrenteRepository.ObterCentroDeCustoPorId(message.Id);

            if (!CentroDeCustoContaCorrenteExistente(message.Id, message.MessageType)) return;

            var centroDeCustoContaCorrente = CentroDeCusto.CentroDeCustoFactory.NovoCentroDeCustoCompleto(
                                                    message.Id, message.Descricao, 
                                                    centroDeCustoContaCorrenteAtual.DataDeCadastro, 
                                                    centroDeCustoContaCorrenteAtual.Ativo);

            if (!CentroDeCustoContaCorrenteValido(centroDeCustoContaCorrente)) return;

            if (Commit())
            {
                Console.WriteLine("Centro de custo atualizado com sucesso");
                _bus.RaiseEvent(new CentroDeCustoContaCorrenteAtualizadoEvent(
                                        centroDeCustoContaCorrente.Id,
                                        centroDeCustoContaCorrente.Descricao,
                                        centroDeCustoContaCorrente.DataDeCadastro));
            }
        }

        public void Handle(ExcluirCentroDeCustoContaCorrenteCommand message)
        {
            if (!CentroDeCustoContaCorrenteExistente(message.Id, message.MessageType)) return;

            var centroDeCustoContaCorrenteAtual = _contaCorrenteRepository.ObterCentroDeCustoPorId(message.Id);

            // TODO:
            // Validacoes de negocio!

            centroDeCustoContaCorrenteAtual.ExcluirCentroDeCusto();

            _contaCorrenteRepository.AtualizarCentroDeCusto(centroDeCustoContaCorrenteAtual);

            if (Commit())
            {
                Console.WriteLine("Centro de custo excluído com sucesso");
                _bus.RaiseEvent(new CentroDeCustoContaCorrenteExcluidoEvent(message.Id));
            }
        }

        private bool CentroDeCustoContaCorrenteValido(CentroDeCusto centroDeCusto)
        {
            if (centroDeCusto.EhValido()) return true;

            NotificarValidacoesErro(centroDeCusto.ValidationResult);
            return false;
        }

        private bool CentroDeCustoContaCorrenteExistente(Guid id, string messageType)
        {
            var centroDeCusto = _contaCorrenteRepository.ObterCentroDeCustoPorId(id);

            if (centroDeCusto != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Centro de custo não encontrado"));
            return false;
        }
        #endregion
    }
}
