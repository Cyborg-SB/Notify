using Microsoft.AspNetCore.Mvc;
using Notify.Entities;
using NotifyApi.Contracts.Models;

namespace NotifyApi.Features.Movies
{
    public class MovieReplaceRequest : EntityBase, IMovieContract
    {
        public MovieReplaceRequest()
        {
            Title = default!;
            Description = default!;
            ReleaseDate = default!;
        }
        public MovieReplaceRequest(Guid id, string title, string description, DateTime realeaseDate)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = realeaseDate;
        }
        [FromRoute(Name = "movie_id")]
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
