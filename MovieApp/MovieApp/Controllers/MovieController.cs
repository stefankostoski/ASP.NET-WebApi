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
        public IActionResult CreateNeMovie([FromBody] MovieViewModel movie)
        {
            //try
            //{
            //   return Ok(_movieService.Create(movie));
            //}
            //catch
            //{
            //    return BadRequest();
            //}
            throw new NotImplementedException();
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
