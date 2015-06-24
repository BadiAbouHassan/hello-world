using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;
using System.Data;

namespace template.DBService
{
    public class ExamScheduleService
    {
        public ExamScheduleService()
        {
        }

        public bool addExamSchedule(ExamSchedule schedule)
        {
            bool result = false;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into ExamSchedule(examID, clubID, scheduledateTime, numberOfSeats) values("
                                + schedule.examID + ", " + schedule.clubID + ", '" + schedule.scheduleDateTime + "'," + schedule.numberOfSeats + ");";

                result= dbObj.executeQuery(query);
               
            }
            dbObj.CloseConnection();

            return result;

        
        }

        public DataSet getSchedulesDataSet()
        {
            SQLClass dbObj = new SQLClass();
            DataSet ds = new DataSet();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from ExamSchedule as a INNER JOIN Exam as b ON a.examID = b.examID";
                SqlDataAdapter myCommand = new SqlDataAdapter(query, cn);
                myCommand.Fill(ds, "ExamSchedule");
            }
            dbObj.CloseConnection();
            return ds;
        }

        public List<ExamSchedule> getExamSchedules(int examID = 0, int scheduleID = 0 )
        {
            List<ExamSchedule> req = new List<ExamSchedule>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (examID != 0)
                {
                    whereCondition = " WHERE examID = " + examID;
                }
                if (scheduleID != 0)
                {
                    whereCondition = ((whereCondition.Length == 0) ? " WHERE " : " AND ") + " examScheduleID = " + scheduleID;
                }

                String query = "Select a.*, b.examName, c.clubName FROM ExamSchedule as a INNER JOIN Exam as b On a.examID = b.examID  INNER JOIN HuntingClub as c ON c.clubID = a.clubID ";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    ExamSchedule request = fillExamSchedule(reader);
                    req.Add(request);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        private ExamSchedule fillExamSchedule(SqlDataReader reader)
        {
            ExamSchedule schedule = new ExamSchedule();

            schedule.examID = Int32.Parse(reader["examID"].ToString());
            schedule.clubID = Int32.Parse(reader["clubID"].ToString());
            schedule.examScheduleID = Int32.Parse(reader["examScheduleID"].ToString());
            schedule.scheduleDateTime = DateTime.Parse(reader["scheduleDateTime"].ToString());
            schedule.numberOfSeats = Int32.Parse(reader["numberOfSeats"].ToString());
            schedule.examName = reader["examName"].ToString();
            schedule.clubName = reader["clubName"].ToString();

            return schedule;
        }
    }
}