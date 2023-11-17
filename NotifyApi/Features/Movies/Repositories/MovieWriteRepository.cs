using NotifyApi.Shared;

namespace NotifyApi.Features.Movies.Repositories
{
    public class MovieWriteRepository : IMovieWriteRepository
    {
        public MovieWriteRepository()
        {
           
        }
       
        public async Task<MovieEntity> CreateMovie(MovieEntity movieEntity)
        {
            try
            {
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.InsertMovie(movieEntity)!;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return default!;
            }
            
        }

        public async Task<MovieEntity> UpdateMovie(MovieEntity movieEntity)
        {
            try
            {               
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.UpdateMovie(movieEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default!;
            }

        }

        public async Task<MovieEntity> ReplaceMovie(MovieEntity movieEntity)
        {
            try
            {
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.ReplaceMovie(movieEntity);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return default!;
            }
            
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            try
            {
                await MemoryDataBase.DefaultInMemoryDelay;

                return MemoryDataBase.DeleteMovie(id).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default!;
            }
        }

    }

    public interface IMovieWriteRepository
    {
        public Task<MovieEntity> CreateMovie(MovieEntity movieEntity);
        public Task<MovieEntity> ReplaceMovie(MovieEntity movieEntity);
        public Task<MovieEntity> UpdateMovie(MovieEntity movieEntity);
        public Task<bool> DeleteMovie(Guid id);
    }
}
