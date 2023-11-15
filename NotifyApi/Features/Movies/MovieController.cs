using Microsoft.AspNetCore.Mvc;
using Notify.Attributes;
using NotifyApi.Features.MoviesFeatures;

namespace NotifyApi.Features.Movies.Controllers
{
    [NotifiableFilter]
    [Route("movies")]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<MovieResponse>))]
        public async Task<IActionResult> MoviesGetAsync([FromServices] IMovieGetService movieGetService)
        {
            var resp = await movieGetService.GetMoviesAsync();
            return Ok(resp);
        }

        [HttpGet("{movie_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        public async Task<IActionResult> MovieGetAsync([FromRoute(Name="movie_id")] string movieId, [FromServices] IMovieGetService movieGetService)
        {
            var resp = await movieGetService.GetMovieAsync(movieId);
            return Ok(resp);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieResponse))]
        public async Task<IActionResult> MovieCreateAsync([FromServices] IMovieCreateService movieCreaetService, [FromBody] MovieCreateRequest movieCreateRequest )
        {
            var resp = await movieCreaetService.CreateMovieAsync(movieCreateRequest);
            return Created(string.Empty, resp);
        }


        [HttpPatch("{movie_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        public async Task<IActionResult> MovieUpadateAsync([FromServices] IMovieUpdateService movieUpdateService, [FromBody] MovieUpdateRequest movieUpdateRequest)
        {
            var resp = await movieUpdateService.UpdateMovieAsync(movieUpdateRequest);

            return Ok(resp);
        }

        [HttpPut("{movie_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        public async Task<IActionResult> MovieReplaceAsync([FromServices] IMovieReplaceService movieReplaceService, [FromBody] MovieReplaceRequest movieReplaceRequest)
        {
            var resp = await movieReplaceService.ReplaceMovie(movieReplaceRequest);
            return Ok(resp);
        }

        [HttpDelete("{movie_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteMovieAsync([FromRoute(Name = "movie_id")] string movieId, [FromServices] IMovieDeleteService movieDeleteService)
        {
            var resp = await movieDeleteService.DeleteMovie(movieId);
            return Ok(resp);
        }
    }
}
