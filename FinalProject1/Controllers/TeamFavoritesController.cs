using FinalProject1.DTO;
using FinalProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TeamFavoritesController : ControllerBase
    {
        private readonly ILogger<TeamFavoritesController> _logger;
        private readonly FinalProjectContext _db;
        private TeamFavoriteResponse teamFavorite;

        public TeamFavoritesController(ILogger<TeamFavoritesController> logger, FinalProjectContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get(int? Id)
        {
            if (Id == null || Id == 0)
            {
                teamFavorite = new TeamFavoriteResponse();
                var response = _db.TeamFavorite
                    .OrderByDescending(x => x.Id)
                    .Take(5);
                foreach (var item in response)
                {
                    teamFavorite.Id = item.Id;
                    teamFavorite.Name = item.Name;
                    teamFavorite.FavColor = item.FavColor;
                    teamFavorite.FavAnimal = item.FavAnimal;
                    teamFavorite.FavNumber = item.FavNumber;
                    teamFavorite.FavSeason = item.FavSeason;
                }
                return Ok(new JsonResult(teamFavorite));
            }
            else
            {
                var result = _db.TeamFavorite.Where(x => x.Id == Id).ToArray();
                return Ok(new JsonResult(result));
            }
        }

        [HttpPost]
        public IActionResult Create(TeamFavorite teamFavorite)
        {
            if (teamFavorite == null)
            {
                return BadRequest("TeamFavorite cannot be null.");
            }
            _db.TeamFavorite.Add(teamFavorite);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = teamFavorite.Id }, teamFavorite);
        }

        [HttpPut]
        public IActionResult Update(TeamFavorite teamFavorite)
        {
            var oldTeamFavorite = _db.TeamFavorite.Find(teamFavorite.Id);
            if (oldTeamFavorite == null)
            {
                return NotFound("TeamFavorite not found.");
            }
            oldTeamFavorite.Name = teamFavorite.Name;
            oldTeamFavorite.FavColor = teamFavorite.FavColor;
            oldTeamFavorite.FavAnimal = teamFavorite.FavAnimal;
            oldTeamFavorite.FavNumber = teamFavorite.FavNumber;
            oldTeamFavorite.FavSeason = teamFavorite.FavSeason;
            _db.Update(oldTeamFavorite);
            _db.SaveChanges();
            return Ok(new JsonResult(teamFavorite));
        }

        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            var teamFavorite = _db.TeamFavorite.Find(Id);
            if (teamFavorite == null)
            {
                return NotFound("TeamFavorite not found.");
            }
            _db.TeamFavorite.Remove(teamFavorite);
            _db.SaveChanges();
            return Ok("TeamFavorite deleted successfully.");
        }



    }
}
