using IMDB.DAL.Entities;
using IMDB.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.Repositories
{
  public  class NotificationsRepository: INotificationsRepository
    {
        public  DateTime? GetLastNotificationDate(int watchListId)
        {
            DateTime? date;
            using (var _context = new IMDBDBContext())
            {
               date =  _context.Notifications.Where(s => s.WatchListId == watchListId).Select(t=>t.NotificationDate).FirstOrDefault();
            }
            return  date;
        }
    }
}
