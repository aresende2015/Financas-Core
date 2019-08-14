using Financas.IO.Domain.Core.Events;
using System;

namespace Financas.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestemp { get; private set; }

        public Command()
        {
            Timestemp = DateTime.Now;
        }
    }
}
