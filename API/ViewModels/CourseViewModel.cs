using API.ViewModels;

namespace API.ViewModels
{
    public class CourseViewModel 
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string ModeOfEducation { get; set; }
        public string CourseCode { get; set; }
        public string Duration { get; set; }
        public string Language { get; set; }
        public string Tutor{get; set;}
        public string Status { get; set; }
    }
}