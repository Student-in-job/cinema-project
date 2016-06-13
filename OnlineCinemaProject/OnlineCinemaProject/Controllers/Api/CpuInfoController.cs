using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using OnlineCinemaProject.Hubs;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers.Api
{
    public class CpuInfoController : ApiController
    {
        public void Post(CpuInfoPostData cpuInfo)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<CpuInfo>();
            context.Clients.All.cpuInfoMessage(cpuInfo.MachineName, cpuInfo.Processor, cpuInfo.MemUsage, cpuInfo.TotalMemory);
        }
    }
}
