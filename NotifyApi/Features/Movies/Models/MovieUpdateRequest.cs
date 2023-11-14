using Microsoft.AspNetCore.Mvc;
using Notify.Entities;
using NotifyApi.Contracts.Models;

namespace NotifyApi.Features.Movies
{
    public class MovieUpdateRequest : EntityBase, IMovieContract
    {
        public MovieUpdateRequest()
        {
            Title = default!;
            Description = default!;
            ReleaseDate = default!;
        }
        public MovieUpdateRequest(Guid id, string title, string description, DateTime realeaseDate)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = realeaseDate;
        }
        [FromRoute(Name ="movie_id")]
        public Guid Id { get;  set; }
        [FromBody]
        public string Title { get; set; }
        [FromBody]
        public string Description { get;  set; }
        [FromBody]
        public DateTime ReleaseDate { get;  set; }
    }
}
