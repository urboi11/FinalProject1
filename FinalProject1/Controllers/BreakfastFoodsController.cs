using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Data;
using FinalProject1.Models;

namespace FinalProject1.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastFoodsController : ControllerBase
    {
        private readonly ILogger<BreakfastFoodsController> _logger;
        private readonly FinalProjectContext _context;

        public BreakfastFoodsController(ILogger<BreakfastFoodsController> logger, FinalProjectContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/GetBreakfastFoods?id=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreakfastFood>>> GetBreakfastFoods(int id)
        {
            if (id == null || id == 0)
            {
                return await _context.BreakfastFoods.Take(5).ToListAsync();
            }

            var item = await _context.BreakfastFoods.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/BreakfastFoods
        [HttpPost]
        public async Task<ActionResult<BreakfastFood>> PostBreakfastFood(string FoodName, bool isSweet, int calories, string originCountry, bool containsGluten)
        {
            BreakfastFood breakfast = new BreakfastFood();
            breakfast.FoodName = FoodName;
            breakfast.IsSweet = isSweet;
            breakfast.Calories = calories;
            breakfast.OriginCountry = originCountry;
            breakfast.ContainsGluten = containsGluten;


            _context.BreakfastFoods.Add(breakfast);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBreakfastFoods), new { id = breakfast.Id }, breakfast);
        }

    // PUT: api/BreakfastFoods/5
    [HttpPut]
    public async Task<IActionResult> PutBreakfastFood([FromQuery] BreakfastFood food)
    {
        try
        {
            _context.BreakfastFoods.Update(food);
            await _context.SaveChangesAsync();
            return Ok();

        }
        catch (Exception E)
        {
            _logger.LogError("Error: " + E);
            return StatusCode(500);
        }    
    }

    // DELETE: api/BreakfastFoods/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBreakfastFood(int id)
    {
        try
        {
            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.BreakfastFoods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();

        }
        catch (Exception e)
        {
            _logger.LogError("Error: " + e);
            return StatusCode(500);
        }
        }
    }
