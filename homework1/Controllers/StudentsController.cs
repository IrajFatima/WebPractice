using homework1.Models;
using homework1.Services;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService sr;

        public StudentsController(StudentService sr)
        {
            this.sr = sr;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = sr.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = sr.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("All Fields are required and should be valid");
                }

                sr.AddStudent(student);
                return Created();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("All Fields are required and should be valid");
                }
                var existingStudent = sr.GetStudentById(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }
                student.StudentId = id;
                sr.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var existingStudent = sr.GetStudentById(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }
                sr.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
