﻿using Financas.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands
{
    public class BaseCentroDeCustoContaCorrenteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }
    }
}
