using IMDB.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.Interface
{
   public interface INotificationsRepository
    {
        public DateTime? GetLastNotificationDate(int watchListId);
        public Task AddNotification(Notifications notification);
    }
}
