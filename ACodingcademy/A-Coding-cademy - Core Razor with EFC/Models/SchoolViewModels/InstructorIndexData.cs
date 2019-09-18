using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_Coding_cademy___Core_Razor_with_EFC.Models.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
