using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class CourseController
    {
        private CourseService courseService;

        public CourseController()
        {
            this.courseService = new CourseService();
        }

        public bool addCourse(Course course)
        {
            bool result = false;

            result = this.courseService.addCourse(course);

            return result;
        }

        public List<Course> getCourses(int courseID = 0)
        {
            return this.courseService.getCourses(courseID);
        }

        internal bool updateCourse(Course course)
        {
            return this.courseService.updateCourse(course);
        }
    }
}