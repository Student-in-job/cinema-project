using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.Utils
{
    /*public static class VideoUtils
    {
        public static VideoInfo GetVideoInfo(video video)
        {
            VideoInfo videoInfo = new VideoInfo
            {
                Id = video.id,
                Name = video.name,
                Poster = video.img_url,
                AgeLimit = video.age_limit,
                Director = video.director,
                Scenario = video.details,
                ReleaseDate = video.release_date,
                Countries = new List<CountryInfo>(),
                Genres = new List<GenreInfo>(),
                Actors = new List<ActorInfo>(),
                Movies = new List<MovieInfo>()
            };
            foreach (var manufacturer in video.manufacturers)
            {
                videoInfo.Countries.Add(new CountryInfo
                {
                    Name = manufacturer.country.name,
                    id = manufacturer.country_id
                });
            }
            foreach (var videoactor in video.videoactors)
            {
                videoInfo.Actors.Add(new ActorInfo
                {
                    Name = videoactor.actor.name,
                    id = videoactor.actor_id
                });
            }
            foreach (var videogenre in video.videogenres)
            {
                videoInfo.Genres.Add(new GenreInfo
                {
                    Name = videogenre.genre.name,
                    id = videogenre.genre_id
                });
            }
            foreach (var movie in video.movies)
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