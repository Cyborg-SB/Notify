using Notify.Services.Interfaces;
using Notify.Validators;
using NotifyApi.Features.Movies;
using NotifyApi.Features.Movies.Repositories;
using Notify;

namespace NotifyApi.Features.MoviesFeatures
{
    public class MovieReplaecService : IMovieReplaceService
    {
        public MovieReplaecService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;


        public async Task<MovieResponse> ReplaceMovie(MovieReplaceRequest request)
        {
            try
            {
                var movieToReplace = await movieGetService.GetMovieAsync(request.Id);

                new ContextContract(notifiable)
                    .ShouldBeTrue(movieToReplace is not null, default)
                    .ShouldBeTrue(DateTime.MinValue.Date != request.ReleaseDate, default)
                    .ShouldBeTrue(DateTime.Now.Date >= request.ReleaseDate.Date, default);


                if (notifiable.Invalid)
                    return default!;

                var movieEnity = new MovieEntity(
                    request.Id,
                    request.Title,
                    request.Description,
                    request.ReleaseDate);

                return await movieWriteRepository.ReplaceMovie(movieEnity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, default!);
                return default!;
            }
           
        }
    }

    public interface IMovieReplaceService
    {
        public Task<MovieResponse> ReplaceMovie(MovieReplaceRequest movieUpdateRequest);
    }
}
