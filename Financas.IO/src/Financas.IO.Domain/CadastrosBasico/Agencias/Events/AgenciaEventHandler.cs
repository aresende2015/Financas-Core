using Financas.IO.Domain.AgenCadastrosBasico.Agenciascias.Events;
using Financas.IO.Domain.Core.Events;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Events
{
    public class AgenciaEventHandler :
        IHandler<AgenciaCadastradaEvent>,
        IHandler<AgenciaAtualizadaEvent>,
        IHandler<AgenciaExcluidaEvent>,
        IHandler<EnderecoAgenciaIncluidoEvent>,
        IHandler<EnderecoAgenciaAtualizadoEvent>
    {
        public void Handle(AgenciaCadastradaEvent message)
        {
            // Enviar um email!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Agência cadastrada com sucesso");
        }

        public void Handle(AgenciaAtualizadaEvent message)
        {
            // Enviar um email!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Agência atualizada com sucesso");
        }

        public void Handle(AgenciaExcluidaEvent message)
        {
            // Enviar um email!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Agência excluída com sucesso");
        }

        public void Handle(EnderecoAgenciaIncluidoEvent message)
        {
            // Enviar um email!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Endereço da agência atualizada com sucesso");
        }

        public void Handle(EnderecoAgenciaAtualizadoEvent message)
        {
            // Enviar um email!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Endereço da agência atualizada com sucesso");
        }
    }
}
