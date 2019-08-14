using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Financas.IO.Domain.Interfaces
{
    public interface IUser
    {
        String Name { get; }

        Guid GetUserId();

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
