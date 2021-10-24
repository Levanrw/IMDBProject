﻿using Hangfire;
using IMDB.Service.Interface;
using IMDB.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController :  ControllerBase
    {
        private readonly IJobSchedulerService _IobSchedulerService;

        public ScheduleController(IJobSchedulerService iobSchedulerService)
        {
            _IobSchedulerService = iobSchedulerService;
        }

        [HttpPost("SendMail")]
        public void SendMail()
        {
           _IobSchedulerService.SendNotification();

           // RecurringJob.AddOrUpdate(() => _IobSchedulerService.SendNotification(), Cron.Minutely());

        }
    }
}
