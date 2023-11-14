using NotifyApi.Shared;

namespace NotifyApi.Features.Movies.Repositories
{
    public class MovieReadRepository : IMovieReadRepository
    {
        public async Task<MovieEntity> GetMovie(Guid id)
        {
            try
            {
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.GetMovie(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return default!;
            }
        }

        public async Task<IEnumerable<MovieEntity>> GetMovies()
        {
            try
            {
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.GetMovies();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Task.FromResult(Enumerable.Empty<MovieEntity>()).Result;
            }
        }
    }

    public interface IMovieReadRepository
    {
        public Task<MovieEntity> GetMovie(Guid id);
        public Task<IEnumerable<MovieEntity>> GetMovies();
    }
}
