using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;      // Correct namespace for AppDbContext
using FinalProject1.Models;    // Correct namespace for FavoriteMovie

namespace FinalProject.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public FavoriteMoviesController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteMovies?id=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> GetFavoriteMovies([FromQuery] int? id)
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
        public async Task<ActionResult<FavoriteMovie>> PostFavoriteMovie(FavoriteMovie movie)
        {
            _context.FavoriteMovies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteMovies), new { id = movie.Id }, movie);
        }

        // PUT: api/FavoriteMovies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteMovie(int id, FavoriteMovie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FavoriteMovies.Any(e => e.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
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