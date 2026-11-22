using System.ComponentModel.DataAnnotations;

namespace Practical11_SmartCampus.Models;

public class CampusEvent
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Display(Name = "Event Name")]
    public string EventName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Venue { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Event Date")]
    public DateTime EventDate { get; set; } = DateTime.Today;

    [Required, StringLength(500)]
    public string Description { get; set; } = string.Empty;
}
