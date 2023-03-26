using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Models;

namespace University.Controllers 

{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase 
    {

        private readonly AppDbContext _uniDbcontext;


        public UniversityController(AppDbContext appDbContext)
        {
            _uniDbcontext = appDbContext;
   
        }



        /*The project should have the following APIs:
         * 
        - Add Student        -->CREATE-POST
        - Remove Student     -->DELETE-DELETE
        - Add Course         -->CREATE-POST   
        - Remove Course      -->DELETE-DELETE

        - Register Student with Course   --->POST **
        - Get all Student                -->READE-GET
        - Get all course                  -->READE-GET
        - Get the student courses        -->READE-GET **
        */




        [HttpPost("Register")]  //Register Student with Course  
        public async Task<IActionResult> RegisterStudentToCourse([FromBody] StudentCourse studentCourse)
        {
            try
            {
                _uniDbcontext.StudentCourses.Add(studentCourse);
                await _uniDbcontext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }





        [HttpPost("Add-Student")] //Add student
        public async Task<IActionResult> AddStudent([FromBody] student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            _uniDbcontext.Students.Add(student);
            await _uniDbcontext.SaveChangesAsync();

            return Ok(new
            {
                id = student.studentId,
                Message = "Student Registered!"
            });

        
        }




        [HttpDelete("Remove-Student")] // Remove Student
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _uniDbcontext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _uniDbcontext.Students.Remove(student);
            await _uniDbcontext.SaveChangesAsync();

            return NoContent();
        }





        [HttpPost("Add-Course")] //Add Course
        public async Task<IActionResult> AddCourse([FromBody]  course course)
        {
            if (course == null)
            {
                return BadRequest();
            }

            _uniDbcontext.Courses.Add(course);
            await _uniDbcontext.SaveChangesAsync();


            return Ok(new
            {
                id = course.courseId,
                Message = "Coures Added!"
            });

        
        }




        [HttpDelete("Remove-Course")] // Remove Course
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _uniDbcontext.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _uniDbcontext.Courses.Remove(course);
            await _uniDbcontext.SaveChangesAsync();

            return NoContent();
        }





        [HttpGet("AllStudents")]  // Get all Student  
        public async Task<ActionResult<student>> getAllStudent()
        {
            return Ok(await _uniDbcontext.Students.ToListAsync());
        }




        [HttpGet("AllCourses")]  // Get all course  
        public async Task<ActionResult<course>> getAllCourses()
        {
            return Ok(await _uniDbcontext.Courses.ToListAsync());
        }





    }



}

