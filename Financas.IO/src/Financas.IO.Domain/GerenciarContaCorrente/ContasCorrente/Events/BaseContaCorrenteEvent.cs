﻿using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events
{
    public class BaseContaCorrenteEvent : Event
    {
        public Guid Id { get; protected set; }

        public string NumeroDaContaCorrente { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }
    }
}
