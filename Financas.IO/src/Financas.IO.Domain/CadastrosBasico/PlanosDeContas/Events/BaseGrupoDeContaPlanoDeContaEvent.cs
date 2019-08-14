using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class BaseGrupoDeContaPlanoDeContaEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
