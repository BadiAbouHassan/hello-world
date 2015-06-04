using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class CourseController
    {
        public bool addCourse(Course course)
        {
            bool result = false;
            CourseService courseService = new CourseService();

            result = courseService.addCourse(course);

            return result;
        }
    }
}