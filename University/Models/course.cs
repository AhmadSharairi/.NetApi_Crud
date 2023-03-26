using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace University.Models
{
    public class course
    {    // Data annotations 
        [Key]
        public int courseId { get; set; }

        public string CourseName { get; set; }

        [JsonIgnore]
        public student student { get; set; }


        [JsonIgnore]
        public IList<StudentCourse> StudentCourses { get; set; }

       
    }
}
