using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace University.Models
{
    public class student
    {
        [Key]
        public int studentId { get; set; }

        [Required]
        public string studentName { get; set; }



         [JsonIgnore]
         public IList<StudentCourse> StudentCourses { get; set; }



    }




  

}
