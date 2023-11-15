using Notify.Services.Interfaces;
using Notify.Validators;
using NotifyApi.Features.Movies;
using NotifyApi.Features.Movies.Repositories;

namespace NotifyApi.Features.MoviesFeatures
{
    public class MovieDeleteService : IMovieDeleteService
    {
        public MovieDeleteService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;


        public async Task<bool> DeleteMovie(string id)
        {
            try
            {
                var isGuid = Guid.TryParse(id, out Guid guid);
                var moveToBeDelete = await movieGetService.GetMovieAsync(guid);

                new ContextContract(notifiable)
                    .ShouldBeTrue(isGuid, 30000)
                    .ShouldBeTrue(moveToBeDelete is not null, 10000);

                if (notifiable.Invalid)
                    return false;

                return await movieWriteRepository.DeleteMovie(guid);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                notifiable.AddNotification(ex.Message, default, default!);
                return false;
            }
           
        }

    }


    public interface IMovieDeleteService
    {
        Task<bool> DeleteMovie(string id);
    }
}
