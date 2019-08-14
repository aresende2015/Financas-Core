using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Events
{
    public class AgenciaCadastradaEvent : BaseAgenciaEvent
    {
        public AgenciaCadastradaEvent(Guid id, int numeroDaAgencia, string nomeDaAgencia, DateTime dataDeCadastro)
        {
            Id = id;
            NumeroDaAgencia = numeroDaAgencia;
            NomeDaAgencia = nomeDaAgencia;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;

        }
    }
}
