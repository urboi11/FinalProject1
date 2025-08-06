using System.ComponentModel.DataAnnotations;

namespace FinalProject1.DTO;

public class FavoriteMovieResponse
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string LeadActor{ get; set; }
}