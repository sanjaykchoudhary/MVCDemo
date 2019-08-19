using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesCL;

namespace ServicesCL
{
    public class CourseService : ICourseService
    {
        public Course GetCourseByID(long courseID)
        {
            return new Course
            {
                CourseID = courseID,
                InstitutionID = 1,
                Title = "Motivational Course",
                Description = "it is course for all the people who needs some motivation in their life."
            };
        }
    }
}
