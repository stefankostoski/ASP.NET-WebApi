using Microsoft.AspNetCore.Mvc;
using MovieApp.Services.Interfaces;
using MovieApp.ViewModels;

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

        [HttpPost("Create")]
        public IActionResult CreateNewMovie([FromBody] MovieViewModel movie)
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
        public IActionResult UpdateMovie([FromBody] MovieViewModel movie)
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
