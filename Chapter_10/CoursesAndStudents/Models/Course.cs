
using System.ComponentModel.DataAnnotations;

namespace Packt.Shared;

public class Course
{
    public int CourseId { get; set; }

    [Required]
    [StringLength(60)]
    public string? Title { get; set; }

    public ICollection<Student>? Students { get; set; }
}