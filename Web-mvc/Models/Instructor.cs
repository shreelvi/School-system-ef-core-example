using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_mvc.Models
{
    public class Instructor: BaseEntity
    {
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}