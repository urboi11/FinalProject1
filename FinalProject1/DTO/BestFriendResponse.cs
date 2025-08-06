using System.ComponentModel.DataAnnotations;
using FinalProject1.Models;

namespace FinalProject1.DTO;

public class BestFriendResponse
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]
    public string Age { get; set; }
    [Required]
    public string Pronouns { get; set; }

}