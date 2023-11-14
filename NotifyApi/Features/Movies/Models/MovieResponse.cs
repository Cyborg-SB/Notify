using Notify.Entities;
using NotifyApi.Contracts.Models;

namespace NotifyApi.Features.Movies
{
    public class MovieResponse : IMovieContract
    {
        public MovieResponse(Guid id, string title, string description, DateTime realeaseDate)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = realeaseDate;            
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set;}

        public static implicit operator MovieResponse(MovieEntity? movie)
        {
            if(movie is null)
                return default!;

            return new MovieResponse(movie.Id,movie.Title,movie.Description,movie.ReleaseDate);
        }

    }
}
