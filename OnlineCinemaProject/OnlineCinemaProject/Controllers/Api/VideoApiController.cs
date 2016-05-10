using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineCinemaProject.CustomResult;
using OnlineCinemaProject.Models;
using OnlineCinemaProject.Models.ViewModels;
// ReSharper disable All

namespace OnlineCinemaProject.Controllers.Api
{
    
    public class VideoApiController : ApiController
    {
        IEnumerable<string> _headerValues;
        string _userId;
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();

        //Get: api/video
        [Route("api/movie")]
        public JSendResponse GetMovies()
        {
            var videos = _db.videos.Where(i=>i.type == video.MOVIE).ToList();
            List<MovieInfo> videoInfos = videos.Select(item => item.GetMovieInfo()).ToList();//todo is that is right?
            return JSendResponse.succsessResponse(videoInfos);
        }
        [Route("api/serial")]
        public JSendResponse GetSerial()
        {
            var videos = _db.videos.Where(i=>i.type == video.SERIAL).ToList();
            List<SerialInfo> videoInfos = videos.Select(item => item.GetSerialInfo()).ToList();//todo is that is right?
            return JSendResponse.succsessResponse(videoInfos);
        }

        //Get: api/video/get/5
        [Route("api/movie/{id}")]
        public JSendResponse GetMovieById(int id)
        {
            video video = _db.videos.Find(id);
            if (video == null)
            {
                return JSendResponse.errorResponse(Error.VideoNotFound());
            }
            return JSendResponse.succsessResponse(video.GetMovieInfo());
        }
        [Route("api/movie/{id}")]
        public JSendResponse GetSerialById(int id)
        {
            video video = _db.videos.Find(id);
            if (video == null)
            {
                return JSendResponse.errorResponse(Error.VideoNotFound());
            }
            return JSendResponse.succsessResponse(video.GetSerialInfo());
        }

        [Route("api/movie/new")]
        public JSendResponse GetNewMovie()
        {
            var videos = _db.videos.Where(i=>i.type == video.MOVIE).OrderByDescending(i=>i.release_date).Take(10).ToList();/*Todo add creation date column to the video table*/
            List<MovieInfo> videoInfos = videos.Select(item => item.GetMovieInfo()).ToList();// todo i dont like i, but i do it
            return JSendResponse.succsessResponse(videoInfos);
        }

        [Route("api/movie/popular")]
        public JSendResponse GetMostPopularMovie()
        {
            var movies = _db.files.OrderByDescending(i => i.histories.Count).Take(10).ToList();
            ICollection<video> videos = movies.Select(movie => movie.video).ToList();
            List<MovieInfo> videoInfos = videos.Select(item => item.GetMovieInfo()).ToList();
            return JSendResponse.succsessResponse(videoInfos);
        }
        [Route("api/serial/new")]
        public JSendResponse GetNewSerials()
        {
            var videos = _db.videos.Where(i=>i.type == video.SERIAL).OrderByDescending(i=>i.release_date).Take(10).ToList();/*Todo add creation date column to the video table*/
            List<SerialInfo> videoInfos = videos.Select(item => item.GetSerialInfo()).ToList();// todo i dont like i, but i do it
            return JSendResponse.succsessResponse(videoInfos);
        }

        [Route("api/serial/popular")]
        public JSendResponse GetMostPopularSerials()//todo 
        {
            var movies = _db.files.OrderByDescending(i => i.histories.Count).Take(10).ToList();
            ICollection<video> videos = movies.Select(movie => movie.video).ToList();
            List<SerialInfo> videoInfos = videos.Select(item => item.GetSerialInfo()).ToList();
            return JSendResponse.succsessResponse(videoInfos);
        }

        [HttpGet]
        [Route("api/video/watch/{file_id}")]
        public JSendResponse WatchVideo(int file_id)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            
            var file = _db.files.Find(file_id);

            if (file == null)
            {
                return JSendResponse.errorResponse(Error.FileNotFoundError());
            }

            if (_userId == null)
            {
                if (file.price == 0)
                {
                    return JSendResponse.succsessResponse();
                }
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }

            aspnetuser user = _db.aspnetusers.Find(_userId);
            if (user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }

            if (!user.CheckAccess(file))
            {
                return JSendResponse.errorResponse(Error.AccessToFileDenied());
            }

            history history = new history
            {
                aspnetuser = user,
                file = file,
                watching_time = DateTime.Now
            };
            
            _db.histories.Add(history);
            _db.SaveChanges();

            return JSendResponse.succsessResponse();
        }

        [HttpGet]
        [Route("api/video/purchase/{file_id}")]
        public JSendResponse PurchaseVideo(int file_id)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            var user = _db.aspnetusers.Find(_userId);
            var file = _db.files.Find(file_id);

            if (user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }
            if (file == null)
            {
                return JSendResponse.errorResponse(Error.FileNotFoundError());
            }


            if (!user.DrawMoney((decimal) file.price))
            {
                return JSendResponse.failResponse("Ндостаточно средств на балансе");
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = (decimal) file.price,
                title = file.getPurchaseTitle(),
                payment_type = false,
                payment_date = DateTime.Now,
            };
            
            _db.payments.Add(payment);
            _db.SaveChanges();

            
            purchase purchase = new purchase
            {
                aspnetuser = user,
                file = file,
                payment = payment,
                purchase_date = DateTime.Now
            };
            _db.purchases.Add(purchase);
                
            
            _db.SaveChanges();
            return JSendResponse.succsessResponse();

        }

        [HttpGet]
        [Route("api/season/purchase/{season_id}")]
        public JSendResponse PurchaseSeason(int season_id)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            var user = _db.aspnetusers.Find(_userId);
            var season = _db.seasons.Find(season_id);

            if (user == null)
            {
                return JSendResponse.errorResponse(Error.UserNotFound());
            }
            if (season == null)
            {
                return JSendResponse.errorResponse(Error.SeasonNotFoundError());
            }


            if (!user.DrawMoney((decimal)season.price))
            {
                return JSendResponse.failResponse("Ндостаточно средств на балансе");
            }

            payment payment = new payment
            {
                aspnetuser = user,
                amount = (decimal)season.price,
                title = "Покупка" + season.season_number + "-го сезона, сериала " + season.video.name,
                payment_type = false,
                payment_date = DateTime.Now,
            };

            _db.payments.Add(payment);
            _db.SaveChanges();

           
            userseason purchase = new userseason
            {
                aspnetuser = user,
                season = season,
                payment = payment,
            };
            _db.userseasons.Add(purchase);
            _db.SaveChanges();
            return JSendResponse.succsessResponse();

        }

        [HttpGet]
        [Route("api/video/search/{key}")]
        public JSendResponse Search(string key)
        {
            var videos = from v in _db.videos where v.type == video.MOVIE select v ;
            ;
            if (!String.IsNullOrEmpty(key))
            {
                videos = videos.Where(s => s.name.ToUpper().Contains(key.ToUpper())
                                       || s.details.ToUpper().Contains(key.ToUpper()));
            }
            List<MovieInfo> videoInfos = new List<MovieInfo>();

            foreach (var item in videos)
            {
                videoInfos.Add(item.GetMovieInfo());
            }
            return JSendResponse.succsessResponse(videoInfos);
        }
        
        [HttpPost]
        [Route("api/overview")]
        [ResponseType(typeof(OverviewModel))]
        public JSendResponse OverView(OverviewModel overviewModel)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            if (!ModelState.IsValid)
            {
                return JSendResponse.errorResponse(Error.ModelStateInvalidError());
            }
             
            review review = new review
            {
                user_id = overviewModel.user_id,
                video_id = overviewModel.video_id,
                rating = overviewModel.rating,
                comment = overviewModel.comment,
                creation_date = DateTime.Now
            };
            _db.reviews.Add(review);
            _db.SaveChanges();

            return JSendResponse.succsessResponse();
        }

        [HttpPut]
        [Route("api/overview/{id}")]
        [ResponseType(typeof(OverviewModel))]
        public JSendResponse OverView(int id, [FromBody] OverviewModel overviewModel)
        {
            if (Request.Headers.TryGetValues("token", out _headerValues))
            {
                _userId = _headerValues.FirstOrDefault();
            }
            if (_userId == null)
            {
                return JSendResponse.errorResponse(Error.UnAuthrizedUserError());
            }
            if (!ModelState.IsValid)
            {
                return JSendResponse.errorResponse(Error.ModelStateInvalidError());
            }

            var overview = _db.reviews.Find(id);
            if (overview == null)
            {
                JSendResponse.errorResponse(Error.CommentNotFoundError());
            }
            if (overview.user_id != _userId)
            {
                JSendResponse.failResponse("нельзя менять чужие комменты");
            }

            overview.rating = overviewModel.rating;
            overview.comment = overviewModel.comment;
            _db.Entry(overview).State = EntityState.Modified;
            _db.SaveChanges();

            return JSendResponse.succsessResponse();
        }
        
        [HttpGet]
        [Route("api/overview/{id}")]
        public JSendResponse GetOverViews(int id)
        {
            var reviews = _db.reviews.Where(i => i.video_id == id).ToList();
            var commentInfos = reviews.Select(overview => new CommentInfo
            {
                id = overview.id, 
                author = overview.aspnetuser.FullName(), 
                authorId = overview.aspnetuser.Id, 
                comment = overview.comment, 
                creationDate = overview.creation_date
            }).ToList();

            return JSendResponse.succsessResponse(commentInfos);
        }

        [HttpGet]
        [Route("api/genre")]
        public JSendResponse GetGenre()
        {
            var genres = _db.genres.ToList();
            List<GenreInfo> genreInfos = new List<GenreInfo>();
            foreach (var genre in genres)
            {
                genreInfos.Add(new GenreInfo()
                {
                    id = genre.id,
                    Name = genre.name
                });
            }
            return JSendResponse.succsessResponse(genreInfos);
        }

        [HttpGet]
        [Route("api/movie/genre/{id}")]
        public JSendResponse GetMoviesByGenre(int id)
        {
            var videos = _db.videogenres.Where(i => i.genre_id == id).Select(i => i.video).Where(i=>i.type == video.MOVIE).ToList();
            List<MovieInfo> videoInfos = new List<MovieInfo>();
            foreach (var item in videos)
            {
                videoInfos.Add(item.GetMovieInfo());
            }
            return JSendResponse.succsessResponse(videoInfos);
        }

        [HttpGet]
        [Route("api/serial/genre/{id}")]
        public JSendResponse GetSerialsByGenre(int id)
        {
            var videos = _db.videogenres.Where(i => i.genre_id == id).Select(i => i.video).Where(i => i.type == video.SERIAL).ToList();
            List<SerialInfo> videoInfos = new List<SerialInfo>();
            foreach (var item in videos)
            {
                videoInfos.Add(item.GetSerialInfo());
            }
            return JSendResponse.succsessResponse(videoInfos);
        }



    }

}
