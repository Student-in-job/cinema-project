using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    public class ApplicationController : Controller
    {
        private OnlineCinemaEntities _db = new OnlineCinemaEntities();

        public OnlineCinemaEntities DataContext
        {
            get { return _db; }
        }
        public ApplicationController()
        {
            ViewBag.Genres = _db.genres.ToList();
        }
	}
}