﻿using Notify.Services.Interfaces;
using Notify.Validators;
using NotifyApi.Features.Movies;
using NotifyApi.Features.Movies.Repositories;

namespace NotifyApi.Features.MoviesFeatures
{
    public class MovieCreateService : IMovieCreateService
    {
        public MovieCreateService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;

        public async Task<MovieResponse> CreateMovieAsync(MovieCreateRequest request)
        {
            try
            {
                var movieToCreate = await movieGetService.GetMovieAsync(request.Id);

                new Contract(notifiable)
                    .ShouldNotBeTrue(movieToCreate is not null, default)
                    .ShouldBeTrue(DateTime.MinValue.Date != request.ReleaseDate.Date, default)
                    .ShouldBeTrue(DateTime.Now.Date <= request.ReleaseDate.Date, default)
                    .ShouldNotBeTrue(string.IsNullOrWhiteSpace(request.Description),default);

                if (notifiable.Invalid)
                    return default!;

                var movieEnity = new MovieEntity(
                    request.Id,
                    request.Title,
                    request.Description,
                    request.ReleaseDate.Date);

                return await movieWriteRepository.CreateMovie(movieEnity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, default!);
                return default!;
            }
            

        }
    }

    public interface IMovieCreateService
    {
        public Task<MovieResponse> CreateMovieAsync(MovieCreateRequest request);
    }
}
