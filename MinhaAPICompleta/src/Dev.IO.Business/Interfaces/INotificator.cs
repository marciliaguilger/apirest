using Dev.IO.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.IO.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
