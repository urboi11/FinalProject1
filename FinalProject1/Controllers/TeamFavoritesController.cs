using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;

namespace FinalProject1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TeamFavoritesController : ControllerBase
    {
        private readonly ILogger<TeamFavoritesController> _logger;
        private readonly FinalProjectContext _db;

        public TeamFavoritesController(ILogger<TeamFavoritesController> logger, FinalProjectContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.TeamFavorite.ToList());
        }


        /*
        // GET: api/TeamFavorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamFavorite>>> GetTeamFavorite()
        {
            return await _context.TeamFavorite.ToListAsync();
        }

        // GET: api/TeamFavorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamFavorite>> GetTeamFavorite(int? id)
        {
            var teamFavorite = await _context.TeamFavorite.FindAsync(id);

            if (teamFavorite == null)
            {
                return NotFound();
            }

            return teamFavorite;
        }

        // PUT: api/TeamFavorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamFavorite(int? id, TeamFavorite teamFavorite)
        {
            if (id != teamFavorite.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamFavorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamFavoriteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeamFavorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamFavorite>> PostTeamFavorite(TeamFavorite teamFavorite)
        {
            _context.TeamFavorite.Add(teamFavorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamFavorite", new { id = teamFavorite.Id }, teamFavorite);
        }

        // DELETE: api/TeamFavorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamFavorite(int? id)
        {
            var teamFavorite = await _context.TeamFavorite.FindAsync(id);
            if (teamFavorite == null)
            {
                return NotFound();
            }

            _context.TeamFavorite.Remove(teamFavorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamFavoriteExists(int? id)
        {
            return _context.TeamFavorite.Any(e => e.Id == id);
        }
        */
    }
}
