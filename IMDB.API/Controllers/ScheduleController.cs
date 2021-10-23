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
        
        [HttpGet("SendMail")]
        public async Task SendMail()
        {
            EmailService serv = new EmailService();
            serv.SendMail("", "");
            //WatchListService watchList = new WatchListService(null, null);
            //watchList.test();
        }
    }
}
