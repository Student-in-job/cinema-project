using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineCinemaProject.CustomResult;
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

        public ActionResult AllVideo(int type)
        {
            var videos = DataContext.videos.Where(i=>i.type == type).ToList();
            return View(videos);
        }

        public ActionResult VideoByGenre(int id)
        {
            var videos = DataContext.videogenres.Where(i => i.genre.id == id).Select(i=>i.video).ToList();
            return View(videos);
        }

        public ActionResult Details(int id)
        {
            var video = DataContext.videos.Find(id);
            var user = DataContext.aspnetusers.Find(User.Identity.GetUserId());
            var file = video.files.FirstOrDefault(i => i.trailer == false);
            if (file != null)
            {
                ViewBag.IsBought = user.checkPurchases(file);
            }
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
            string query = "SELECT * FROM teasers where active = '1' order by show_amount asc";
            var banner = DataContext.teasers.Where(i => i.active == true).OrderBy(i => i.showAmount).ToList().First();
            statistics_teaser sb = new statistics_teaser();
            try
            {
                sb = DataContext.statistics_teaser.Single(i => i.id_teasers == banner.id && i.id_users == User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                //e.Data;
            };


            DataContext.teasers.Attach(banner);
            if (banner.showAmount == null)
            {
                banner.showAmount = 0;
            }

            banner.showAmount = banner.showAmount + 1;
            var entry = DataContext.Entry(banner);
            entry.Property(e => e.showAmount).IsModified = true;
            // other changed properties
            DataContext.SaveChanges();

            if (sb.teaser != null)
            {

                DataContext.statistics_teaser.Attach(sb);
                sb.dateShow = DateTime.Now;
                sb.showAmount = (int?)banner.showAmount;

                var entry1 = DataContext.Entry(sb);
                entry1.Property(e => e.showAmount).IsModified = true;
                entry1.Property(e => e.dateShow).IsModified = true;
                // other changed properties
                DataContext.SaveChanges();
            }
            else
            {
                sb = new statistics_teaser();
                sb.dateShow = DateTime.Now;
                sb.id_teasers = banner.id;
                sb.showAmount = (int?)banner.showAmount;
                sb.id_users = User.Identity.GetUserId();
                DataContext.statistics_teaser.Add(sb);
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

        [HttpGet]
        public ActionResult WatchVideo(int file_id)
        {

            var file = DataContext.files.Find(file_id);

            if (!User.Identity.IsAuthenticated)
            {
                if (file.price == 0)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            aspnetuser user = DataContext.aspnetusers.Find(User.Identity.GetUserId());
            

            if (!user.CheckAccess(file))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            history history = new history
            {
                aspnetuser = user,
                file = file,
                watching_time = DateTime.Now
            };

            DataContext.histories.Add(history);
            DataContext.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult WatchSeason(int file_id)
        {

            var file = DataContext.files.Find(file_id);

            var season = file.season;
            if (!User.Identity.IsAuthenticated)
            {
                if (file.price == 0)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            aspnetuser user = DataContext.aspnetusers.Find(User.Identity.GetUserId());


            if (!user.CheckAccess(season))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            history history = new history
            {
                aspnetuser = user,
                file = file,
                watching_time = DateTime.Now
            };

            DataContext.histories.Add(history);
            DataContext.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PurchaseVideo(int file_id)
        {
            
            var user = DataContext.aspnetusers.Find(User.Identity.GetUserId());
            var file = DataContext.files.Find(file_id);


            if (!user.DrawMoney((decimal)file.price))
            {
                return Json(JSendResponse.errorResponse(Error.LackOfMoney()), JsonRequestBehavior.AllowGet);
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = (decimal)file.price,
                title = file.getPurchaseTitle(),
                payment_type = false,
                payment_date = DateTime.Now,
            };

            DataContext.payments.Add(payment);
            DataContext.SaveChanges();


            purchase purchase = new purchase
            {
                aspnetuser = user,
                file = file,
                payment = payment,
                purchase_date = DateTime.Now
            };
            DataContext.purchases.Add(purchase);

            DataContext.SaveChanges();
            return Json(JSendResponse.succsessResponse(file.url), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult PurchaseSeason(int file_id)
        {

            var user = DataContext.aspnetusers.Find(User.Identity.GetUserId());
            var file = DataContext.files.Find(file_id);
            var season = file.season;

            if (!user.DrawMoney((decimal)season.price))
            {
                return Json( JSendResponse.errorResponse(Error.LackOfMoney()), JsonRequestBehavior.AllowGet);
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = (decimal)season.price,
                title = "покупка " + season.season_number+" го сезона, сериала " + season.video.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };

            DataContext.payments.Add(payment);
            DataContext.SaveChanges();


            userseason userseason = new userseason
            {
                aspnetuser = user,
                season = file.season,
                payment = payment,
            };
            DataContext.userseasons.Add(userseason);

            DataContext.SaveChanges();
            return Json(JSendResponse.succsessResponse(file.url), JsonRequestBehavior.AllowGet);

        }

    }
}