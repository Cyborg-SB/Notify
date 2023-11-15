using Notify.Services.Interfaces;
using NotifyApi.Features.Movies;
using NotifyApi.Features.Movies.Repositories;

namespace NotifyApi.Features.MoviesFeatures
{
    public class MovieUpdateService : IMovieUpdateService
    {
        public MovieUpdateService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;

        public async Task<MovieResponse> UpdateMovieAsync(MovieUpdateRequest request)
        {
            try
            {

                var movieToUpdate = await movieGetService.GetMovieAsync(request.Id);

                if (movieToUpdate is null)
                {
                    notifiable.AddNotification(string.Empty, default, request.Id.ToString());
                    return default!;
                }

                if ((DateTime.MinValue.Date == request.ReleaseDate.Date) ||
                   (DateTime.Now.Date < request.ReleaseDate))
                {
                    notifiable.AddNotification(string.Empty, default, request.Id.ToString());
                    return default!;
                }

                var movieEnity = new MovieEntity(
                    request.Id,
                    string.IsNullOrWhiteSpace(request.Title) ? movieToUpdate.Title : request.Title,
                    string.IsNullOrWhiteSpace(request.Description) ? movieToUpdate.Description : request.Description,
                    request.ReleaseDate);

                return await movieWriteRepository.UpdateMovie(movieEnity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, default!);
                return default!;


            }
        }
    }

    public interface IMovieUpdateService
    {
        public Task<MovieResponse> UpdateMovieAsync(MovieUpdateRequest id);
    }
}
