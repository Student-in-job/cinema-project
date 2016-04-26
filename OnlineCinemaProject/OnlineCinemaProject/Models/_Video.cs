using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

// ReSharper disable All

namespace OnlineCinemaProject.Models
{
    public class VideoInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ageLimit { get; set; }
        public DateTime releaseDate { get; set; }
        public string scenario { get; set; }
        public string director { get; set; }
        public string poster { get; set; }
        public double rating { get; set; }
        /*public int likes { get; set; }*/

        public List<ActorInfo> actors;

        public List<GenreInfo> genres;
        
        public List<CountryInfo> countries;

        public List<MovieInfo> movies;

        public List<CommentInfo> comments;
    }

    public class ActorInfo
    {
        public int id;

        public string Name;
    }

    public class GenreInfo
    {
        public int id;

        public string Name;
    }

    public class CountryInfo
    {
        public int id;

        public string Name;
    }

    public class MovieInfo
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public int quality { get; set; }
    }

    public class CommentInfo
    {
        public int id;
        public string author;
        public string authorId;
        public string comment;
        public DateTime? creationDate;
    }

    public partial class video
    {
        public VideoInfo GetVideoInfo()
        {
            VideoInfo videoInfo = new VideoInfo
            {
                id = id,
                name = name,
                poster = img_url,
                ageLimit = age_limit,
                director = director,
                scenario = details,
                releaseDate = release_date,
                /*likes = likes.Count,*/
                rating = GetRating(),
                
                countries = new List<CountryInfo>(),
                genres = new List<GenreInfo>(),
                actors = new List<ActorInfo>(),
                movies = new List<MovieInfo>(),
                comments = new List<CommentInfo>()
            };
            foreach (var manufacturer in manufacturers)
            {
                videoInfo.countries.Add(new CountryInfo
                {
                    Name = manufacturer.country.name,
                    id = manufacturer.country_id
                });
            }
            foreach (var videoactor in videoactors)
            {
                videoInfo.actors.Add(new ActorInfo
                {
                    Name = videoactor.actor.name,
                    id = videoactor.actor_id
                });
            }
            foreach (var videogenre in videogenres)
            {
                videoInfo.genres.Add(new GenreInfo
                {
                    Name = videogenre.genre.name,
                    id = videogenre.genre_id
                });
            }
            foreach (var movie in movies)
            {
                videoInfo.movies.Add(new MovieInfo
                {
                    price = movie.price,
                    id = movie.id,
                    quality = movie.quality
                });
            }
            var counter = 3;
            foreach (var comment in overviews.OrderByDescending(i=>i.creation_date))
            {
                if (counter < 3 && comment.comment!=null)
                {
                    videoInfo.comments.Add(new CommentInfo
                    {
                        id = comment.id,
                        author = comment.aspnetuser.FullName(),
                        authorId = comment.aspnetuser.Id,
                        comment = comment.comment,
                        creationDate = comment.creation_date
                    });
                }
                
                counter -= 1;

            }
            return videoInfo;
        }

        public Double GetRating()
        {
            double? rating = 0;
            foreach (var overview in overviews)
            {
                rating += overview.rating;
            }
            double? totalRating = rating/overviews.Count;
            return totalRating.Value;
        }
    }
}