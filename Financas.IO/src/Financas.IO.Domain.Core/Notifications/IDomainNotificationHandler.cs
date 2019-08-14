using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        List<T> GetNotifications();
    }
}
