using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_mvc.Models
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int? id);
        Task<IReadOnlyList<Student>> GetStudentsAsync();
        Task<Student> GetStudentDetailsAsync(int? id);
        Task CreateStudentAsync(Student student);
        Task EditStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
        
    }
}