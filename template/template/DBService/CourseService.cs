using System;
using System.Collections.Generic;
using System.Web;
using template.Controllers;
using template.DBModel;
using System.Data.SqlClient;

namespace template.DBService
{
    public class CourseService
    {
        public bool addCourse(DBModel.Course course)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "INSERT INTO Course(courseName, courseDesc)" +
                               "Values('" + course.courseName + "', '" + course.courseDesc + "')";
                result = dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
            return result;
        }

        public DBModel.Course[] getCourses(int courseID = 0)
        {
            DBModel.Course[] result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String whereCondition = "";
                if (courseID != 0)
                {
                    whereCondition = " WHERE courseID = " + courseID;
                }
                String query = "SELECT * FROM Course " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);
                int incr = 0;
                while (reader.Read())
                {
                    result[incr] = fillCourse(reader);
                    incr++;
                }
            }
            dbObj.CloseConnection();

            return result;
        }

        public DBModel.Course fillCourse(SqlDataReader reader)
        {
            DBModel.Course course = null;

            course.courseName = reader["courseName"].ToString();

            return course;
        }
    }
}