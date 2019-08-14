using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class BasePlanoDeContaEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public TipoDeMovimentacao TipoDeMovimento { get; set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
