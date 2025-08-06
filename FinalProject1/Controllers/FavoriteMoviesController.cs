using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;      // Correct namespace for AppDbContext
using FinalProject1.Models;
using FinalProject1.DTO;    // Correct namespace for FavoriteMovie

namespace FinalProject.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly ILogger<FavoriteMoviesController> _logger;
        private readonly FinalProjectContext _context;

        public FavoriteMoviesController(ILogger<FavoriteMoviesController> logger, FinalProjectContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/FavoriteMovies?id=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> GetFavoriteMovies([FromQuery] int id)
        {
            if (id == null || id == 0)
            {
                return await _context.FavoriteMovies.Take(5).ToListAsync();
            }

            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST: api/FavoriteMovies
        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> PostFavoriteMovie([FromQuery] FavoriteMovieResponse movieResponse)
        {
            FavoriteMovie movie = new FavoriteMovie
            {
                Title = movieResponse.Title,
                Genre = movieResponse.Genre,
                ReleaseYear = movieResponse.ReleaseYear,
                Director = movieResponse.Director,
                LeadActor = movieResponse.LeadActor
            };
            
            _context.FavoriteMovies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteMovies), new { id = movie.Id }, movie);
        }

    // PUT: api/FavoriteMovies/5
    [HttpPut]
    public async Task<IActionResult> PutFavoriteMovie([FromQuery] FavoriteMovie movie)
    {
        try
        {
            _context.FavoriteMovies.Update(movie);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("Error: " + e);
            return StatusCode(500);
        }    
    }

        // DELETE: api/FavoriteMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMovie(int id)
        {
            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }