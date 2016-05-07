using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewBag.Slider = DataContext.videos.OrderByDescending(i => i.release_date).Take(5).ToList();
            ViewBag.NewFilm = DataContext.videos.Where(i => i.type == video.MOVIE).OrderByDescending(i => i.release_date).Take(6).ToList();
            ViewBag.NewSerial = DataContext.videos.Where(i => i.type == video.SERIAL).OrderBy(i => i.release_date).Take(12).ToList();
            ViewBag.PopularFilm = DataContext.videos.Where(i => i.type == video.MOVIE).OrderByDescending(i => i.release_date).Take(12).ToList();
            ViewBag.PopularSerial = DataContext.videos.Where(i => i.type == video.SERIAL).OrderBy(i => i.release_date).Take(1).ToList();
            
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Video(int id)
        {
            var video = DataContext.videos.Find(id);

            return View(video);
        }

        public ActionResult Profile(string name)
        {
            aspnetuser aspnetuser = DataContext.aspnetusers.Single(i=>i.UserName == name);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }

            ICollection<subscription> subscriptions = DataContext.subscriptions.Where(i => i.user_id == aspnetuser.Id).ToList();
            ViewBag.subscriptions = subscriptions;
            return View(aspnetuser);
        }


    }
}