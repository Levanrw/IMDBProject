using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Entities
{
   public class Notifications
    {
        public Notifications(int userId, int watchListId, DateTime notificationDate)
        {
            UserId = userId;
            WatchListId = watchListId;
            NotificationDate = notificationDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int WatchListId { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
