namespace University.Models
{
    public class StudentCourse
    {

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegistrationDate { get; set; }


        public student Student { get; set; }
        public course  Course { get; set; }

    }
}
