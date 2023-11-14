using Notify.Entities;
using NotifyApi.Contracts.Models;

namespace NotifyApi.Features.Movies
{
    public class MovieEntity : Notifiable, IMovieContract
    {
        public MovieEntity(Guid id, string title, string description, DateTime realeaseDate)
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

        public static implicit operator MovieEntity(MovieReplaceRequest movieContract) =>
             new (movieContract.Id, movieContract.Title, movieContract.Description, movieContract.ReleaseDate);

        public static implicit operator MovieEntity(MovieUpdateRequest movieContract) =>
            new (movieContract.Id, movieContract.Title, movieContract.Description, movieContract.ReleaseDate);

        public static implicit operator MovieEntity(MovieCreateRequest movieContract) =>
            new (movieContract.Id, movieContract.Title, movieContract.Description, movieContract.ReleaseDate);

    }
}
