using Microsoft.AspNetCore.Mvc;
using WebApiWork06.Models;
using System.Linq;

namespace WebApiWork06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> Students = new List<Student>();

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(Students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = Students.FirstOrDefault(a => a.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            // Id'yi otomatik olarak ayarla
            student.Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;

            if (Students.Any(a => a.Id == student.Id))
            {
                return BadRequest();
            }
            Students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Class = updatedStudent.Class;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            Students.Remove(student);
            return Ok();
        }
    }
}