using System.Collections.Generic;
using System.Threading.Tasks;
using Web_mvc.Models;

namespace Web_mvc.Data
{
    public class CourseRepository: ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public Task<Course> GetCourseByIdAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Course> GetCourseDetailsAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Course>> GetCoursesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}