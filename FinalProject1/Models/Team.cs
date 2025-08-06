using FinalProject1.DTO;

namespace FinalProject1.Models;

public class Team 
{
    public Int64 Id { get; set; }

    public string? TeamMember { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? CollegeProgram { get; set; }

    public string? Year { get; set; }

}