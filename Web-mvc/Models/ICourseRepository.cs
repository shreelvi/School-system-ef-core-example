using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_mvc.Models
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(int? id);
        Task<IReadOnlyList<Course>> GetCoursesAsync();
        Task<Course> GetCourseDetailsAsync(int? id);
    }
}