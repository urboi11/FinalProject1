using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FinalProject1.Models;

namespace FinalProject1.DTO;

public class TeamsResponse
{
    [Required]
    public string TeamName { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }

    [Required]
    public string CollegeProgram { get; set; }
    
    [Required]
    public string Year { get; set; }
}