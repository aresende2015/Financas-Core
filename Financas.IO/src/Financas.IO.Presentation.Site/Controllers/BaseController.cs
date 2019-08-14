using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Financas.IO.Presentation.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;

        public Guid ClienteId { get; set; }

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications,
                              IUser user)
        {
            _notifications = notifications;
            _user = user;

            if (_user.IsAuthenticated())
            {
                ClienteId = _user.GetUserId();
            }
            
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }


    }
}
