using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Controllers;
using University.Models;

namespace University.UtilityService
{
    public class UserRepository : IUserRepository
    {
        private readonly UniversityController _uniController;
        private readonly AppDbContext _uniDbcontext;

        public UserRepository(AppDbContext dbContext)
        {
            _uniDbcontext = dbContext;

        }

        public async void register(StudentCourse StudentCourse)
        {
            await _uniController.RegisterStudentToCourse(StudentCourse);
            _uniDbcontext.SaveChangesAsync(); ;
        }

        public async void addStudent(student student)
        {
            await _uniController.AddStudent(student);
            _uniDbcontext.SaveChanges();
        }
        public async void deleteStudent(int id)
        {
            await _uniController.DeleteStudent(id);
            _uniDbcontext.SaveChanges();
        }

        public async void addCourse(course course)
        {
            await _uniController.AddCourse(course);
            _uniDbcontext.SaveChanges();
        }

        public async void deleteCourse(int id)
        {
            await _uniController.DeleteCourse(id);
            _uniDbcontext.SaveChanges();

        }
        public Task<ActionResult<student>> allStudent()
        {
            return _uniController.getAllStudent();
        }

        public Task<ActionResult<course>> allCourses()
        {

            return _uniController.getAllCourses();

        }


    }
}

