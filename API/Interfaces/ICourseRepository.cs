using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        void Add(AddCourseViewModel course);
    Task<IEnumerable<CourseViewModel>> GetCoursesAsync();
     Task<CourseViewModel> GetCourseByNameAsync(string name);
    Task<CourseViewModel> GetCourseByCourseCodeAsync(string code);
    Task<CourseViewModel> GetCourseByIdAsync(int id);
    Task<IEnumerable<CourseViewModel>> GetCourseByStatusAsync(string status);
     Task<IEnumerable<CourseViewModel>> GetCourseByTutorAsync(string tutor);
      Task<IEnumerable<CourseViewModel>> GetCourseByLanguageAsync(string language);
       Task<IEnumerable<CourseViewModel>> GetCourseByModeAsync(string mode);
    void Delete(CourseViewModel course);
    void Update(CourseViewModel course);
    }
}