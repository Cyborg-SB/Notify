namespace NotifyApi.Features.Movies
{
    public struct MoviesResponse
    {
        public MoviesResponse(IEnumerable<MovieEntity> movieEntities)
        {
            Movies = ParseMovieEntitiesToMovieResponse(movieEntities);
        }
        public IEnumerable<MovieResponse> Movies { get; private set; }

        private static IEnumerable<MovieResponse> ParseMovieEntitiesToMovieResponse(IEnumerable<MovieEntity> movieEntities)
        {
            var resp = new List<MovieResponse>();

            foreach (var movieEntity in movieEntities)
            {
                resp.Add(movieEntity);
            }

            return resp;
        }

    }
}
