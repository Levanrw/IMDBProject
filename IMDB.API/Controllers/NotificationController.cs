using Hangfire;
using IMDB.Service.Interface;
using IMDB.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]

    [Route("[controller]")]
   
    public class NotificationController :  ControllerBase
    {
        private readonly IJobSchedulerService _IobSchedulerService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iobSchedulerService"></param>
        public NotificationController(IJobSchedulerService iobSchedulerService)
        {
            _IobSchedulerService = iobSchedulerService;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost("SendMail")]
        public void SendMail()
        {
          _IobSchedulerService.SendNotification();

          //  RecurringJob.AddOrUpdate(() => _IobSchedulerService.SendNotification(), Cron.Weekly(DayOfWeek.Friday,19,30));

        }
    }
}
