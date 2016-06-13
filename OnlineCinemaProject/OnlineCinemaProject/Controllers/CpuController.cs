using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CpuController : Controller
    {
        //
        // GET: /Cpu/
        public ActionResult Index()
        {
            return View();
        }

       
       
    }
}
