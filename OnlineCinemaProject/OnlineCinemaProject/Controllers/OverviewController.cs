using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "ContentManager")]
    public class OverviewController : Controller
    {
        private OnlineCinemaEntities db = new OnlineCinemaEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Users_read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = db.aspnetusers.Select(v => new { name = v.FirstName + " " + v.LastName, user_id = v.Id }).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Comments_read([DataSourceRequest]DataSourceRequest request, int videoId)
        {
            DataSourceResult result = db.reviews.Where(t => t.video_id == videoId).Select(v => new CommentModel { id = v.id, user_id =  v.aspnetuser.Id, user = new UserViewModel {name = v.aspnetuser.FirstName + " " + v.aspnetuser.LastName ,user_id = v.user_id}, comment = v.comment, video_id = v.video_id, creation_date = v.creation_date, rating = v.rating}).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Comments_create([DataSourceRequest]DataSourceRequest request, CommentModel overview, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = db.reviews.Add(new review { video_id = videoId, user_id = overview.user.user_id, comment = overview.comment, creation_date = overview.creation_date, rating = overview.rating});
                db.SaveChanges();
                overview.id = entity.id;
            }

            return Json(new[] { overview }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Comments_update([DataSourceRequest]DataSourceRequest request, CommentModel overview, int videoId)
        {
            if (ModelState.IsValid)
            {
                var entity = new review()
                {
                    id=overview.id,
                    video_id = videoId,
                    user_id = overview.user.user_id,
                    comment = overview.comment,
                    rating = overview.rating,
                    creation_date = overview.creation_date
                };
                db.reviews.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { overview }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Comments_destroy([DataSourceRequest]DataSourceRequest request, CommentModel overview)
        {
            if (ModelState.IsValid)
            {
                var entity = new review()
                {
                    id = overview.id
                };
                db.reviews.Attach(entity);
                db.reviews.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { overview }.ToDataSourceResult(request, ModelState));
        }
    }
}