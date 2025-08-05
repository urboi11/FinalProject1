using System.Text.Json.Nodes;
using FinalProject1.DTO;
using FinalProject1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FinalProject1.Data;

namespace FinalProject1.Controllers;


[ApiController]
[Route("[controller]")]

public class TeamsController : ControllerBase
{
    private readonly FinalProjectContext _db;
    private readonly ILogger<Team> _logger;

    public TeamsController(ILogger<Team> logger, FinalProjectContext db)
    {
        _logger = logger;
        _db = db;
    }
    [HttpGet("GetTeamsMembers")]
    public ActionResult GetTeamMembers(int? Id) {

        if (Id == null || Id == 0)
        {
            // TeamsResponse team = new TeamsResponse();

            var response = _db.Teams.Take(5).ToList();

            return Ok(response);
        }
        else
        {
            var response = _db.Teams.Where(x => x.Id == Id).DefaultIfEmpty().ToList();
            if (response[0] == null)
            {
                return NotFound(Id + " was not found.");
            }
            return new JsonResult(response);
        }

    }
    [HttpPost("CreateTeamMember")]
    public async Task<ActionResult<Team>> CreateTeamMember([FromQuery] Team team)
    {
        _db.Teams.Add(team);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTeamMembers), new { id = team.Id }, team);
    }

    [HttpDelete("DeleteTeamMember")]
    public void DeleteTeamMember(Int64 Id)
    {
        Team response = _db.Teams.Find(Id);
        _db.Teams.Remove(response);
        _db.SaveChanges();
    }

    [HttpPut("UpdateTeamMember")]
    public async Task<ActionResult<Team>> UpdateTeamMember([FromQuery] Team team)
    {
        try
        {
            _db.Teams.Update(team);
            _db.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("Error: " + e);
            return StatusCode(500);
        }
    }
    
}