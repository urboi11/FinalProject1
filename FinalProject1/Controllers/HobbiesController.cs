using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;    // Correct namespace for AppDbContext
using FinalProject1.Models;  // Correct namespace for Hobby

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public HobbiesController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/Hobbies?id=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobbies([FromQuery] Int64 id)
        {
            if (id == null || id == 0)
            {
                return await _context.Hobbies.Take(5).ToListAsync();
            }

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }

            return Ok(hobby);
        }

        // POST: api/Hobbies
        [HttpPost]
        public async Task<ActionResult<Hobby>> PostHobby(String name, int frequencyPerWeek, bool indoorOrOutdoors, string skillLevel, string description)
        {
            Hobby hobby1 = new Hobby();

            hobby1.Name = name;
            hobby1.FrequencyPerWeek = frequencyPerWeek;
            hobby1.Indoor = indoorOrOutdoors;
            hobby1.SkillLevel =skillLevel;
            hobby1.Description = description;
            
            _context.Hobbies.Add(hobby1);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Hobbies/5
        [HttpPut]
        public async Task<IActionResult> PutHobby([FromQuery] Hobby hobby)
        {
            try
            {
                _context.Hobbies.Update(hobby);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            // if (id != hobby.Id)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(hobby).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!_context.Hobbies.Any(e => e.Id == id))
            //     {
            //         return NotFound();
            //     }

            //     throw;
            // }

            // return NoContent();
        }

        // DELETE: api/Hobbies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobby(Int64 id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
