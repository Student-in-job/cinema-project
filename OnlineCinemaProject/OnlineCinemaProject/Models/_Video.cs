using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ActorInfo> actors;

        public List<GenreInfo> genres;
        
        public List<CountryInfo> countries;

        public List<CommentInfo> comments;
        
        public TrailerInfo trailer;
    }

    public class MovieInfo : VideoInfo
    {
        public List<FileInfo> files;
    }

    public class SerialInfo : VideoInfo
    {
        public List<SeasonInfo> seasons;
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
        public const int SERIAL = 1;
        public const int MOVIE = 0;

        public VideoInfo GetVideoInfo()
        {
            VideoInfo videoInfo = new VideoInfo()
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
            
            var tr = files.Where(i => i.trailer == true).FirstOrDefault();
            if (tr != null)
            {
                videoInfo.trailer = new TrailerInfo
                {
                    id = tr.id,
                    title = tr.title,
                    url = tr.url
                };
            }

            var counter = 3;
            foreach (var comment in reviews.OrderByDescending(i => i.creation_date))
            {
                if (counter < 3 && comment.comment != null)
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

        public MovieInfo GetMovieInfo()
        {
            MovieInfo movieInfo = new MovieInfo
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
                files = new List<FileInfo>(),
                comments = new List<CommentInfo>()
            };
            foreach (var manufacturer in manufacturers)
            {
                movieInfo.countries.Add(new CountryInfo
                {
                    Name = manufacturer.country.name,
                    id = manufacturer.country_id
                });
            }
            foreach (var videoactor in videoactors)
            {
                movieInfo.actors.Add(new ActorInfo
                {
                    Name = videoactor.actor.name,
                    id = videoactor.actor_id
                });
            }
            foreach (var videogenre in videogenres)
            {
                movieInfo.genres.Add(new GenreInfo
                {
                    Name = videogenre.genre.name,
                    id = videogenre.genre_id
                });
            }
            foreach (var file in files)
            {
                movieInfo.files.Add(new FileInfo
                {
                    price = file.price,
                    id = file.id,
                    quality = file.quality,
                    url = file.url
                });
            }
            var tr = files.Where(i => i.trailer == true).FirstOrDefault();
            if (tr != null)
            {
                movieInfo.trailer = new TrailerInfo
                {
                    id = tr.id,
                    title = tr.title,
                    url = tr.url
                };
            }
            
            var counter = 3;
            foreach (var comment in reviews.OrderByDescending(i=>i.creation_date))
            {
                if (counter < 3 && comment.comment!=null)
                {
                    movieInfo.comments.Add(new CommentInfo
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
            return movieInfo;
        }

        public SerialInfo GetSerialInfo()
        {
            SerialInfo serialInfo = new SerialInfo
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
                seasons = new List<SeasonInfo>(),
                comments = new List<CommentInfo>()
            };
            foreach (var manufacturer in manufacturers)
            {
                serialInfo.countries.Add(new CountryInfo
                {
                    Name = manufacturer.country.name,
                    id = manufacturer.country_id
                });
            }
            foreach (var videoactor in videoactors)
            {
                serialInfo.actors.Add(new ActorInfo
                {
                    Name = videoactor.actor.name,
                    id = videoactor.actor_id
                });
            }
            foreach (var videogenre in videogenres)
            {
                serialInfo.genres.Add(new GenreInfo
                {
                    Name = videogenre.genre.name,
                    id = videogenre.genre_id
                });
            }
            var tr = files.Where(i => i.trailer == true).FirstOrDefault();
            if (tr != null)
            {
                serialInfo.trailer = new TrailerInfo
                {
                    id = tr.id,
                    title = tr.title,
                    url = tr.url
                };
            }
            
            foreach (var season in seasons)
            {
                SeasonInfo seasonInfo = new SeasonInfo();
                seasonInfo.id = season.id;
                seasonInfo.season_number = (int)season.season_number;
                seasonInfo.price = (decimal)season.price;
                seasonInfo.title = season.title;
                seasonInfo.episodes = new List<EpisodeInfo>();
                foreach (var item in season.files)
                {
                    seasonInfo.episodes.Add(new EpisodeInfo
                    {
                        id = item.id,
                        episode_number = item.episode_number,
                        quality = item.quality,
                        url = item.url,
                        title = item.title
                    });
                }
                serialInfo.seasons.Add(seasonInfo);
            }
            var counter = 3;
            foreach (var comment in reviews.OrderByDescending(i => i.creation_date))
            {
                if (counter < 3 && comment.comment != null)
                {
                    serialInfo.comments.Add(new CommentInfo
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
            return serialInfo;
        }

        public Double GetRating()
        {
            double? rating = 0;
            foreach (var overview in reviews)
            {
                rating += overview.rating;
            }
            double? totalRating = rating/reviews.Count;
            return (double) totalRating;
        }

        public void UpdateVideoActors(int[] selectedActors, List<actor> allActors )
        {
            if (selectedActors == null)
            {
                videogenres = new List<videogenre>();
                return;
            }

            var selectedActorsHS = new HashSet<int>(selectedActors);
            var videoActors = new HashSet<int>(videoactors.Select(c => c.actor_id));
            foreach (var actor in allActors)
            {
                if (selectedActorsHS.Contains(actor.id))
                {
                    if (!videoActors.Contains(actor.id))
                    {
                        var videoactor = new videoactor();
                        videoactor.actor_id = actor.id;
                        videoactor.video_id = id;
                        videoactors.Add(videoactor);
                    }
                }
                else
                {
                    if (videoActors.Contains(actor.id))
                    {
                        videoactors.Remove(videoactors.FirstOrDefault(g => g.actor_id == actor.id));
                    }
                }
            }
        }

        public void UpdateVideoGenres(int[] selectedGenres, List<genre> allGenres)
        {
            if (selectedGenres == null)
            {
                videogenres = new List<videogenre>();
                return;
            }

            var selectedGenresHS = new HashSet<int>(selectedGenres);
            var videoGenres = new HashSet<int>(videogenres.Select(c => c.genre_id));
            foreach (var genre in allGenres)
            {
                if (selectedGenresHS.Contains(genre.id))
                {
                    if (!videoGenres.Contains(genre.id))
                    {
                        var videogenre = new videogenre();
                        videogenre.genre_id = genre.id;
                        videogenre.video_id = id;
                        videogenres.Add(videogenre);
                    }
                }
                else
                {
                    if (videoGenres.Contains(genre.id))
                    {
                        videogenres.Remove(videogenres.FirstOrDefault(g => g.genre_id == genre.id));
                    }
                }
            }
        }

        public void UpdateVideoCountries(int[] selectedCountries, List<country> allCountries)
        {
            if (selectedCountries == null)
            {
                manufacturers = new List<manufacturer>();
                return;
            }

            var selectedCountriesHS = new HashSet<int>(selectedCountries);
            var videoCountries = new HashSet<int>(manufacturers.Select(c => c.country_id));
            foreach (var country in allCountries)
            {
                if (selectedCountriesHS.Contains(country.id))
                {
                    if (!videoCountries.Contains(country.id))
                    {
                        var manufacturer = new manufacturer();
                        manufacturer.country_id = country.id;
                        manufacturer.video_id = id;
                        manufacturers.Add(manufacturer);
                    }
                }
                else
                {
                    if (videoCountries.Contains(country.id))
                    {
                        manufacturers.Remove(manufacturers.FirstOrDefault(g => g.country_id == country.id));
                    }
                }
            }
        }
    }
}