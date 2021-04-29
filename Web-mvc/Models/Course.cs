using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_mvc.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}