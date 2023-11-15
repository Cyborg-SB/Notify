using Notify.Entities;
using NotifyApi.Contracts.Models;
using System.Text.Json.Serialization;

namespace NotifyApi.Features.Movies
{
    public class MovieCreateRequest : EntityBase, IMovieContract
    {
        public MovieCreateRequest()
        {
            Title = default!; 
            Description = default!;
            ReleaseDate = default!;
        }
        public MovieCreateRequest( string title, string description, DateTime realeaseDate)
        {
            Title = title;
            Description = description;
            ReleaseDate = realeaseDate;
        }
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        

    }
}
