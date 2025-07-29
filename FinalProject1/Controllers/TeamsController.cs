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
            var response = _db.Teams.Where(x => x.Id == Id).ToArray();
            return new JsonResult(response);
        }

    }
    [HttpPut("CreateTeamMember")]
    public void CreateTeamMember(string name, DateTime birthDate, string collegeProgram, string year)
    {
        Team teamMate = new Team();
        teamMate.TeamMember = name;
        teamMate.BirthDate = DateOnly.FromDateTime(birthDate);
        teamMate.CollegeProgram = collegeProgram;
        teamMate.Year = year;
        var response = _db.Teams.Add(teamMate);
        _db.SaveChanges();
    }

    [HttpDelete("DeleteTeamMember")]
    public void DeleteTeamMember(int Id) {
        var response = _db.Teams.Where(x => x.Id == Id);
        _db.Remove(response);
    }

    [HttpPut("UpdateTeamMember")]


}