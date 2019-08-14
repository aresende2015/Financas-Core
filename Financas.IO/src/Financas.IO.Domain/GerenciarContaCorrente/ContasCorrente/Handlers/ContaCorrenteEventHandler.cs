using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Handlers
{
    public class ContaCorrenteEventHandler :
        IHandler<ContaCorrenteCadastradaEvent>,
        IHandler<ContaCorrenteAtualizadaEvent>,
        IHandler<ContaCorrenteExcluidaEvent>,
        IHandler<CentroDeCustoContaCorrenteCadastradoEvent>,
        IHandler<CentroDeCustoContaCorrenteAtualizadoEvent>,
        IHandler<CentroDeCustoContaCorrenteExcluidoEvent>,
        IHandler<ClienteContaCorrenteCadastradoEvent>,
        IHandler<ClienteContaCorrenteAtualizadoEvent>,
        IHandler<ClienteContaCorrenteExcluidoEvent>,
        IHandler<LancamentoContaCorrenteCadastradoEvent>,
        IHandler<LancamentoContaCorrenteAtualizadoEvent>,
        IHandler<LancamentoContaCorrenteExcluidoEvent>
    {
        public void Handle(ContaCorrenteCadastradaEvent message)
        {
            // Enviar um email!
        }

        public void Handle(ContaCorrenteAtualizadaEvent message)
        {
            // Enviar um email!
        }

        public void Handle(ContaCorrenteExcluidaEvent message)
        {
            // Enviar um email!
        }

        public void Handle(CentroDeCustoContaCorrenteCadastradoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(CentroDeCustoContaCorrenteAtualizadoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(CentroDeCustoContaCorrenteExcluidoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(ClienteContaCorrenteCadastradoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(ClienteContaCorrenteAtualizadoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(ClienteContaCorrenteExcluidoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(LancamentoContaCorrenteCadastradoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(LancamentoContaCorrenteAtualizadoEvent message)
        {
            // Enviar um email!
        }

        public void Handle(LancamentoContaCorrenteExcluidoEvent message)
        {
            // Enviar um email!
        }
    }
}
