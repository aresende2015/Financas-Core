using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class ContaCorrenteCadastradaEvent : BaseContaCorrenteEvent
    {
        public ContaCorrenteCadastradaEvent(Guid id, string numeroDaContaCorrente, DateTime dataDeCadastro)
        {
            Id = id;
            NumeroDaContaCorrente = numeroDaContaCorrente;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
