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
                    whereCondition = " WHERE ID = " + courseID;
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

            course.courseID   = int.Parse(reader["ID"].ToString()); 
            course.courseName = reader["courseName"].ToString();
            course.courseDesc = reader["courseDesc"].ToString();

            return course;
        }
    }
}