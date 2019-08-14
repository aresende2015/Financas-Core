using Financas.IO.Domain.Core.Events;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Bancos.Events
{
    public class BancoEventHandler :
        IHandler<BancoCadastradoEvent>,
        IHandler<BancoAtualizadoEvent>,
        IHandler<BancoExcluidoEvent>
    {
        public void Handle(BancoCadastradoEvent message)
        {
            // Enviar um email!
            Console.WriteLine("Banco registrado com sucesso");
        }

        public void Handle(BancoAtualizadoEvent message)
        {
            // Enviar um email!
            Console.WriteLine("Banco atualizado com sucesso");
        }

        public void Handle(BancoExcluidoEvent message)
        {
            // Enviar um email!
            Console.WriteLine("Banco excluído com sucesso");
        }
    }
}
