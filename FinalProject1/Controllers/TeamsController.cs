using FinalProject1.DTO;
using FinalProject1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Controllers;


[ApiController]
[Route("[controller]")]

public class TeamsController : ControllerBase
{
    private readonly FinalProjectContext _db;

    public TeamsController(FinalProjectContext db) {
        _db = db;
    }
    [HttpGet("GetTeamInformation")]
    public ActionResult GetTeamInformation()
    {
        var result = _db.Teams.ToList();

        return Ok(result);
    }
    [HttpGet("GetTeamsInformationById")]
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
            var response = _db.Teams.AsNoTracking()
                                    .First();
            return Ok(response);
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

    // [HttpDelete("DeleteTeamMember")]

    // [HttpPut("UpdateTeamMember")]


}