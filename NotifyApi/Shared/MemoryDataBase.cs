using NotifyApi.Features.Movies;

namespace NotifyApi.Shared
{
    public static class MemoryDataBase
    {
        public static Task DefaultInMemoryDelay { get; } =  Task.Delay(new Random().Next(30, 90));

        private static readonly object locker = new ();

        private static readonly List<MovieEntity> inMemoryDataBase = new()
        {
            new (
                Guid.NewGuid(),
                "Scarface e Batman",
                "Crossover inesperado",
                new DateTime(1993,8,1)),
            new (
                Guid.NewGuid(),
                "Um ato de coragem",
                "Com Denzel",
                new DateTime(2001,11,30))
        };


        public static IEnumerable<MovieEntity> GetMovies()
        {
            return inMemoryDataBase;
        }
        public static MovieEntity GetMovie(Guid id)
        {
            return inMemoryDataBase.FirstOrDefault(x=>x.Id == id)!;
        }


        public static MovieEntity InsertMovie(MovieEntity movieEntity)
        {
            lock (locker)
            {
                inMemoryDataBase.Add(movieEntity);
            }

            return movieEntity;
        }

        public static MovieEntity UpdateMovie(MovieEntity movieEntity)
        {
            lock (locker)
            {
                inMemoryDataBase.Remove(movieEntity);
            }

            return movieEntity;
        }

        public static MovieEntity ReplaceMovie(MovieEntity movieEntity)
        {
           lock (locker)
           {
                DeleteMovie(movieEntity.Id);

                inMemoryDataBase.Add(movieEntity);
           }

            return movieEntity;
        }

        public static Task<bool> DeleteMovie(Guid id)
        {
            lock (locker)
            {
                inMemoryDataBase.Remove(GetMovie(id));
            }

            return Task.FromResult(true); 
        }
    }
}
