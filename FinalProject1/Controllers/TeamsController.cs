using System.Text.Json.Nodes;
using FinalProject1.DTO;
using FinalProject1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinalProject1.Controllers;


[ApiController]
[Route("[controller]")]

public class TeamsController : ControllerBase
{
    private readonly FinalProjectContext _db;

    public TeamsController(FinalProjectContext db) {
        _logger = logger;
        _db = db;
    }

    [HttpGet("GetTeamsInformation")]
    public ActionResult GetTeamMembers(int? Id) {

        if (Id == null || Id == 0)
        {
            TeamsResponse team = new TeamsResponse();

            var response = _db.Teams.AsNoTracking()
                            .OrderByDescending(x => x.Id)
                            .Take(5);

            foreach (var item in response)
            {
                team.Id = item.Id;
                team.TeamMember = item.TeamMember;
                team.BirthDate = item.BirthDate;
                team.CollegeProgram = item.CollegeProgram;
                team.Year = item.Year;
            }

            return Ok(team);
        }
        else
        {
            var response = _db.Teams.Where(x => x.Id == Id).DefaultIfEmpty().ToArray();
            if (response[0] == null)
            {
                return NotFound(Id + " was not found.");
            }
            return new JsonResult(response);
        }

    }
    [HttpPut("CreateTeamMember")]
    public void CreateTeamMember(string name, DateOnly birthDate, string collegeProgram, string year)
    {
        Team teamMate = new Team();
        teamMate.TeamMember = name;
        teamMate.BirthDate = birthDate;
        teamMate.CollegeProgram = collegeProgram;
        teamMate.Year = year;
        var response = _db.Teams.Add(teamMate);
        _db.SaveChanges();
    }

    [HttpDelete("DeleteTeamMember")]
    public void DeleteTeamMember(int Id)
    {
        // var response = _db.Teams.Where(x => x.Id == Id);
        Team response = _db.Teams.Find(Id);
        _db.Teams.Remove(response);
        _db.SaveChanges();
    }

    [HttpPut("UpdateTeamMember")]
    public ActionResult UpdateTeamMember(int Id, string name, DateOnly birthDate, string collegeProgram, string year)
    {
        Team response = _db.Teams.Find(Id);
        if (response == null)
        {
            return NotFound("Not Found.");
        }
        response.TeamMember = name;
        response.BirthDate = birthDate;
        response.CollegeProgram = collegeProgram;
        response.Year = year;
        _db.Update(response);
        _db.SaveChanges();
        return Ok();
    }
    
}