using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models
{
    public class VideoInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Scenario { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }

        public List<ActorInfo> Actors;

        public List<GenreInfo> Genres;
        
        public List<CountryInfo> Countries;

        public List<MovieInfo> Movies;
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

   /*public partial class video
    {
        public VideoInfo GetVideoInfo()
        {
            VideoInfo videoInfo = new VideoInfo
            {
                Id = id,
                Name = name,
                Poster = img_url,
                AgeLimit = age_limit,
                Director = director,
                Scenario = details,
                ReleaseDate = release_date,
                Countries = new List<CountryInfo>(),
                Genres = new List<GenreInfo>(),
                Actors = new List<ActorInfo>(),
                Movies = new List<MovieInfo>()
            };
            foreach (var manufacturer in manufacturers)
            {
                videoInfo.Countries.Add(new CountryInfo
                {
                    Name = manufacturer.country.name,
                    id = manufacturer.country_id
                });
            }
            foreach (var videoactor in videoactors)
            {
                videoInfo.Actors.Add(new ActorInfo
                {
                    Name = videoactor.actor.name,
                    id = videoactor.actor_id
                });
            }
            foreach (var videogenre in videogenres)
            {
                videoInfo.Genres.Add(new GenreInfo
                {
                    Name = videogenre.genre.name,
                    id = videogenre.genre_id
                });
            }
            foreach (var movie in movies)
            {
                videoInfo.Movies.Add(new MovieInfo
                {
                    price = movie.price,
                    id = movie.id,
                    quality = movie.quality
                });
            }
            return videoInfo;
        }
    }*/
}