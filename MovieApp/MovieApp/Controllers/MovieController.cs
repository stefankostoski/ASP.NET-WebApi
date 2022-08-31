using Microsoft.AspNetCore.Mvc;
using MovieApp.InterfaceModels;
using MovieApp.Services.Interfaces;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllMovies()
        {
            try
            {
                return Ok(_movieService.GetAll());
            }
            catch
            {
                return BadRequest("There are no movies in the database.");
            }
        }

        [HttpGet("GetByGenre")]
        public IActionResult GetByGenre([FromRoute] string genre)
        {
            try
            {
                return Ok(_movieService.GetByGenre(genre));
            }
            catch
            {
                return new NotFoundObjectResult($"The movie with genre: {genre} was not found in the database!");
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateNewMovie([FromBody] Movie movie)
        {
            try
            {
                _movieService.Create(movie);
                return Ok("Movie created successfully!");
            }
            catch
            {
                return BadRequest();
            }
            throw new NotImplementedException();
        }

        [HttpPut("Update")]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                _movieService.Update(movie);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteMovieById([FromRoute] int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
