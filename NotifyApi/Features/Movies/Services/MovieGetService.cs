using Notify.Services.Interfaces;
using NotifyApi.Features.Movies;
using NotifyApi.Features.Movies.Repositories;

namespace NotifyApi.Features.MoviesFeatures
{
    public class MovieGetService : IMovieGetService
    {
        public MovieGetService(IMovieReadRepository movieReadRepository, INotifiableContext notifiable)
        {
            this.movieReadRepository = movieReadRepository;
            this.notifiable = notifiable;
        }
        private readonly IMovieReadRepository movieReadRepository;
        private readonly INotifiableContext notifiable;

        public async Task<MovieResponse> GetMovieAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guid))
                {
                    notifiable.AddNotification(string.Empty, default, id);
                    return default!;
                }
                return await GetMovieAsync(guid);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, id);
                return default!;
            }
            
        }    

        public async Task<MovieResponse> GetMovieAsync(Guid id)
        {    
            return await movieReadRepository.GetMovie(id);
        }
        public async Task<IEnumerable<MovieResponse>> GetMoviesAsync()
        {
            try
            {
                var movies = await movieReadRepository.GetMovies();
                var response = new List<MovieResponse>();

                foreach (var movie in movies)
                {
                    response.Add(movie);
                }

                return response;
            }   
            catch(Exception ex){
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, default!);
                return default!;
            }
        }
    }

    public interface IMovieGetService
    {
        Task<MovieResponse> GetMovieAsync(string id);
        Task<MovieResponse> GetMovieAsync(Guid id);
        Task<IEnumerable<MovieResponse>> GetMoviesAsync();
    }
}
