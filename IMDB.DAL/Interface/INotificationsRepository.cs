using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Interface
{
   public interface INotificationsRepository
    {
        public DateTime? GetLastNotificationDate(int watchListId);
    }
}
