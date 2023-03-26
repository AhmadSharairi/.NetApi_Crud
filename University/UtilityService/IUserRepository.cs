using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Controllers;
using University.Models;

namespace University.UtilityService
{
    public interface IUserRepository
    {  //   CRUD OPERATIONS FOR USER   (Repository Pattren) 
        public void register(StudentCourse Student_Course);
        public void addStudent(student stu);
        public void deleteStudent(int id);
        public void addCourse(course co);
        public void deleteCourse(int id);
        public Task<ActionResult<student>> allStudent();
        public Task<ActionResult<course>> allCourses();
    }


}
