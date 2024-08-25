using System.ComponentModel.DataAnnotations;

namespace WebApiWork06.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    public string Class { get; set; }
}