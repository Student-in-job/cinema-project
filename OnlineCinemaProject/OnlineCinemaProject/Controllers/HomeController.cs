using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewBag.Slider = DataContext.videos.OrderByDescending(i => i.release_date).Take(5).ToList();
            ViewBag.NewFilm = DataContext.videos.Where(i => i.type == video.MOVIE).OrderByDescending(i => i.release_date).Take(12).ToList();
            ViewBag.NewSerial = DataContext.videos.Where(i => i.type == video.SERIAL).OrderByDescending(i => i.release_date).Take(12).ToList();
            ViewBag.PopularFilm = DataContext.videos.Where(i => i.type == video.MOVIE).OrderByDescending(i => i.score).Take(12).ToList();
            ViewBag.PopularSerial = DataContext.videos.Where(i => i.type == video.SERIAL).OrderByDescending(i => i.score).Take(12).ToList();
            
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

        public ActionResult Search(string search_input)
        {
            var videos = from v in DataContext.videos select v;
            if (!String.IsNullOrEmpty(search_input))
            {
                videos = videos.Where(s => s.name.ToUpper().Contains(search_input.ToUpper())
                                       || s.details.ToUpper().Contains(search_input.ToUpper()));
            }

            
            ViewBag.Search_input = search_input;
            return View(videos.ToList());
        }
        
        public ActionResult VideoByGenre(int id)
        {
            var videos = DataContext.videogenres.Where(i => i.genre.id == id).Select(i=>i.video).ToList();
            return View(videos);
        }

        public ActionResult Details(int id)
        {
            var video = DataContext.videos.Find(id);

            return View(video);
        }

        public ActionResult UserCabinet(string name)
        {
            aspnetuser aspnetuser = DataContext.aspnetusers.Single(i=>i.UserName == name);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }

            var subs = DataContext.subscriptions.Where(i => i.user_id == aspnetuser.Id && i.end > DateTime.Now).ToList();
            ViewBag.subscriptions = subs;
            ViewBag.tariffs = DataContext.tariffs.ToList();
            return View(aspnetuser);
        }

        [HttpGet]
        public ActionResult RotatorRoma()
        {
            string query = "SELECT * FROM banners where active = '1' order by show_amount asc";
            var banner = DataContext.banners.Where(i => i.active == true).OrderBy(i => i.show_amount).ToList().First();
            statistics_banner sb = new statistics_banner();
            try
            {
                sb = DataContext.statistics_banner.Single(i => i.id_banner == banner.id && i.id_user == User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                //e.Data;
            };


            DataContext.banners.Attach(banner);
            banner.show_amount = banner.show_amount + 1;
            var entry = DataContext.Entry(banner);
            entry.Property(e => e.show_amount).IsModified = true;
            // other changed properties
            DataContext.SaveChanges();

            if (sb.banner != null)
            {

                DataContext.statistics_banner.Attach(sb);
                sb.date = DateTime.Now;
                sb.show_amount = (int?)banner.show_amount;

                var entry1 = DataContext.Entry(sb);
                entry1.Property(e => e.show_amount).IsModified = true;
                entry1.Property(e => e.date).IsModified = true;
                // other changed properties
                DataContext.SaveChanges();
            }
            else
            {
                sb = new statistics_banner();
                sb.date = DateTime.Now;
                sb.id_banner = banner.id;
                sb.show_amount = (int?)banner.show_amount;
                sb.id_user = User.Identity.GetUserId();
                DataContext.statistics_banner.Add(sb);
                DataContext.SaveChanges();

            }

            return Json(banner.img_url, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ViewResult SearchVideo(string search_input)
        {
            var videos = from v in DataContext.videos select v;
            if (!String.IsNullOrEmpty(search_input))
            {
                videos = videos.Where(s => s.name.ToUpper().Contains(search_input.ToUpper())
                                       || s.details.ToUpper().Contains(search_input.ToUpper()));
            }

            ViewBag.Videos = videos;
            return View(search_input);
        }


    }
}