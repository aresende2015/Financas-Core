using Financas.IO.Domain.Core.Commands;
using Financas.IO.Domain.Interfaces;
using Financas.IO.Infra.Data2.Context;

namespace Financas.IO.Infra.Data2.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancaEFContext _context;

        public UnitOfWork(FinancaEFContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAfetadas = _context.SaveChanges();
            return new CommandResponse(rowsAfetadas > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
