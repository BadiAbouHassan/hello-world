using System;
using System.Collections.Generic;
using System.Web;
using template.Controllers;
using template.DBModel;
using System.Data.SqlClient;
using System.Data;

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

        public List<Course> getCourses(int courseID = 0)
        {
            List<Course> result = null;

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
                
                result = new List<Course>();
                while (reader.Read())
                {
                    result.Add(fillCourse(reader));
                }
            }
            dbObj.CloseConnection();
            return result;
        }
        public Course getCourseById(int courseID = 0)
        {
            Course result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "SELECT * FROM Course WHERE courseID = " +courseID;
                SqlDataReader reader = dbObj.selectQuery(query);
                result = new Course();
                if (reader.Read())
                {
                    result = fillCourse(reader);
                }
            }
            dbObj.CloseConnection();
            return result;
        }

        public DataSet getCourseDataSet()
        {
            SQLClass dbObj = new SQLClass();
            DataSet ds = new DataSet();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from Course";
                SqlDataAdapter myCommand = new SqlDataAdapter(query, cn);
                myCommand.Fill(ds, "Course");
            }
            dbObj.CloseConnection();
            return ds;
        }

        public DBModel.Course fillCourse(SqlDataReader reader)
        {
            DBModel.Course course = new Course();

            course.courseID   = int.Parse(reader["courseID"].ToString()); 
            course.courseName = reader["courseName"].ToString();
            course.courseDesc = reader["courseDesc"].ToString();

            return course;
        }

        internal bool updateCourse(Course course)
        {
            SQLClass dbObj = new SQLClass();

            SqlConnection conn = dbObj.openConnection();
            // add the insert between transaction and commit in order no to lose data integratiy ... 
            using (conn)
            {

                String query = "update  Course set courseName ='" + course.courseName + "', "
                                + "courseDesc = '" + course.courseDesc + "' "
                                + "where courseID =" + course.courseID;


                dbObj.executeQuery(query);

            }

            dbObj.CloseConnection();
            return true;
        }
    }
}