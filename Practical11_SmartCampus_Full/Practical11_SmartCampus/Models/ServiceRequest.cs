using System.ComponentModel.DataAnnotations;

namespace Practical11_SmartCampus.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required, StringLength(70)]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required, StringLength(60)]
    public string Department { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Issue { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = "Pending";

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
