using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Commands
{
    public class AtualizarAgenciaCommand : BaseAgenciaCommand
    {
        public AtualizarAgenciaCommand(
            Guid id, 
            int numeroDaAgencia, 
            string nomeDaAgencia,
            Guid bancoId)
        {
            Id = id;
            NumeroDaAgencia = numeroDaAgencia;
            NomeDaAgencia = nomeDaAgencia;
            BancoId = bancoId;
        }
    }
}
