using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using System.Data;
using System.Data.SqlClient;
using template.Controllers;

namespace template.DBService
{
    public class ExamReservationService
    {
        public ExamReservationService()
        {
        }

        public int addExamrRservation(ExamReservation reservation)
        {
            int result = 0;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "INSERT INTO ExamReservation(examScheduleID, applicantID, registerationID) OUTPUT INSERTED.reservationID VALUES ("
                                + reservation.examScheduleID + ", " + reservation.applicantID + ", " + reservation.registerationID + ");";

                result = dbObj.executeQueryAndReturnLastID(query);
            }
            dbObj.CloseConnection();

            return result;
        }

        public List<ExamReservation> getExamReservations(int examID = 0, int examScheduleID = 0, int applicantID = 0)
        {
            List<ExamReservation> req = new List<ExamReservation>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (examID != 0)
                {
                    whereCondition = " WHERE examID = " + examID;
                }
                if (examScheduleID != 0)
                {
                    whereCondition = ((whereCondition.Length == 0) ? " WHERE " : " AND ") + " examScheduleID = " + examScheduleID;
                }
                if (applicantID != 0)
                {
                    whereCondition = ((whereCondition.Length == 0) ? " WHERE " : " AND ") + " c.applicantID = " + applicantID;
                }

                String query = "Select a.* " + 
                               "FROM ExamReservation as a " +
                               "INNER JOIN RegistrationRequests as b On a.registerationID = b.registerationID  " +
                               "INNER JOIN Applicant as c ON b.applicantID = c.applicantID " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    ExamReservation reservation = this.fillExamReservation(reader);
                    req.Add(reservation);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        public List<ExamReservation> getAllReservationsOfUserAfterToday(String today,User user = null)
        {
            List<ExamReservation> list = new List<ExamReservation>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = " ";
                if (user != null)
                {
                    whereCondition = "AND u.userID=" + user.userID;
                }
                String query = "Select a.* " +
                               "FROM ExamReservation as a " +
                               "INNER JOIN ExamSchedule as e ON a.examScheduleID = e.examScheduleID " +
                               "INNER JOIN HuntingClub as c ON e.clubID = c.clubID "+
                               "INNER JOIN UserTable as u ON c.adminUserID = u.userID "+
                               "where e.scheduledateTime > '"+today + "'"+ whereCondition ;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    ExamReservation reservation = this.fillExamReservation(reader);
                    list.Add(reservation);
                }

            }
            dbObj.CloseConnection();

            return list;
        }

        private ExamReservation fillExamReservation(SqlDataReader reader)
        {
            ExamReservation reservation = new ExamReservation();

            reservation.reservationID = Int32.Parse(reader["reservationID"].ToString());
            reservation.applicantID = Int32.Parse(reader["applicantID"].ToString());
            reservation.examScheduleID = Int32.Parse(reader["examScheduleID"].ToString());
            reservation.registerationID = int.Parse(reader["registerationID"].ToString());

            return reservation;
        }
    }
}