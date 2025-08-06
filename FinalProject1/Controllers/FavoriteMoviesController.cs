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
        private readonly ILogger<FavoriteMoviesController> 
        private readonly FinalProjectContext _context;

        public FavoriteMoviesController(FinalProjectContext context)
        {
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
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFavoriteMovie(FavoriteMovie movie)
    {
        try
        {

        }
        catch (Exception e)
        {
            
        }    
    }

        // DELETE: api/FavoriteMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMovie(Int64 id)
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