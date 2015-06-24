using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using System.Data.SqlClient;
using template.Controllers;

namespace template.DBService
{
    public class FieldExamService
    {
        public int addFieldExamResult(FieldExam fieldExam)
        {
            int result = 0;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "INSERT INTO FieldExam(examInstanceID, result, notes) OUTPUT INSERTED.fieldExamID VALUES ("
                                + fieldExam.examInstanceID + ", " + fieldExam.result + ", '" + fieldExam.notes + "');";

                result = dbObj.executeQueryAndReturnLastID(query);
            }
            dbObj.CloseConnection();

            return result;
        }

        public List<FieldExam> getFieldExamResult(int examInstanceID)
        {
            List<FieldExam> req = new List<FieldExam>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (examInstanceID != 0)
                {
                    whereCondition = " WHERE examInstanceID = " + examInstanceID;
                }
                
                String query = "Select * " +
                               "FROM FieldExam " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    FieldExam fieldExam = this.fillFieldExam(reader);
                    req.Add(fieldExam);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        private FieldExam fillFieldExam(SqlDataReader reader)
        {
            FieldExam fieldExam = new FieldExam();

            fieldExam.fieldExamID = Int32.Parse(reader["fieldExamID"].ToString());
            fieldExam.examInstanceID = Int32.Parse(reader["examInstanceID"].ToString());
            fieldExam.result = decimal.Parse(reader["result"].ToString());
            fieldExam.notes = reader["notes"].ToString();

            return fieldExam;
        }
    }
}