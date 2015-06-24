using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ApplicantService
    {
        /// <summary>
        ///  this function select Applicant of given paswod and Applicantname --> for login aurhentication
        /// </summary>
        public Applicant checkApplicantAuthentication(String username, String password)
        {
            Applicant Applicant = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Applicant where username= N'" + username + "' AND pass =N'" + password + "'";
                
                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    Applicant = fillApplicant(reader);
                }
            }
            dbObj.CloseConnection();
            return Applicant;
        }

        public void activateApplicantByID(int ID)
        {
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "update  Applicant set accountActivated = 1 where applicantID="+ID;

                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
        }


        public Applicant getApplicantOfID(int ID)
        {
            Applicant Applicant = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Applicant where applicantID= " +ID;

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    Applicant = fillApplicant(reader);
                }
            }
           
            dbObj.CloseConnection();
            return Applicant;
        }


        public Applicant getApplicantOfActivationCode(String activationCode)
        {
            Applicant Applicant = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Applicant where activationCodeToken= '" + activationCode + "'";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    Applicant = fillApplicant(reader);
                }
            }

            dbObj.CloseConnection();
            return Applicant;
        }

        /// <summary>
        ///  this function select Applicant of given paswod and Applicantname --> for login aurhentication
        /// </summary>
        public Applicant addApplicant(Applicant Applicant,RegistrationRequests req)
        {

            SQLClass dbObj = new SQLClass();
           
            SqlConnection conn = dbObj.openConnection();
            // add the insert between transaction and commit in order no to lose data integratiy ... 
            using (conn)
            {
               
                        //SqlTransaction transaction;

                        //// Start a local transaction.
                        //transaction = conn.BeginTransaction("SampleTransaction");

                        //// Must assign both transaction object and connection 
                        //// to Command object for a pending local transaction
                        //command.Connection = conn;
                        //command.Transaction = transaction;

                        String query = "insert into Applicant(username, pass,firstname,middlename ,lastname,gender,dateOfBirth,placeOfBirth,registrationNb,"
                                    + "nationality,bloodType,Profession,email,mailAddress,fax,city,applicantAddress,cellular,phone,accountActivated,activationCodeToken,userActivation) OUTPUT inserted.applicantID values(N'"
                                        + Applicant.username + "', N'" + Applicant.password + "', N'" + Applicant.firstname + "',N'" + Applicant.middlename + "', N'"
                                        + Applicant.lastname + "', '" + Applicant.gender + "', '" + Applicant.dateOfBirth + "', N'" + Applicant.placeOfBirth + "','"
                                        + Applicant.registrationNb + "',N'" + Applicant.nationality + "', '" + Applicant.bloodType + "',N'" + Applicant.profession + "','"
                                        + Applicant.email + "',N'" + Applicant.mailAddress + "','" + Applicant.fax + "',N'" + Applicant.city + "',N'" + Applicant.applicantAddress + "','"
                                        + Applicant.cellular + "','" + Applicant.phone + "','" +Applicant.accountActivated+"','"+Applicant.activationCodeToken+"','"+Applicant.userActivation+"'); ";

                       // command.CommandText = query;
                        SqlDataReader reader = dbObj.selectQuery(query);
                        if (reader.Read())
                        {
                            Applicant.applicantID = Int32.Parse(reader["applicantID"].ToString());
                            RegistrationRequestService reqService = new RegistrationRequestService();
                            req.applicantID = Applicant.applicantID;
                            reader.Close();
                            req = reqService.addRequestByCnx(req, dbObj);
                        }
                        else
                        {
                            Applicant = null;
                        }
                    }

            dbObj.CloseConnection();
            return Applicant;
        }


        /// <summary>
        ///  this function fill Applicant object
        /// </summary>
        public Applicant fillApplicant(SqlDataReader reader)
        {
            Applicant Applicant = new Applicant();
            Applicant.applicantID = Int32.Parse(reader["applicantID"].ToString());
            Applicant.username = reader["username"].ToString();
            Applicant.registrationNb = reader["registrationNb"].ToString();
            Applicant.nationality = reader["nationality"].ToString();
            Applicant.firstname = reader["firstname"].ToString();
            Applicant.middlename = reader["middlename"].ToString();
            Applicant.bloodType = reader["bloodType"].ToString();
            Applicant.profession = reader["Profession"].ToString();
            Applicant.gender = reader["gender"].ToString();
            Applicant.mailAddress = reader["mailAddress"].ToString();
            Applicant.fax = reader["fax"].ToString();
            Applicant.dateOfBirth = reader["dateOfBirth"].ToString();
            Applicant.placeOfBirth = reader["placeOfBirth"].ToString();
            Applicant.city = reader["city"].ToString();
            Applicant.lastname = reader["lastname"].ToString();
            Applicant.cellular = reader["cellular"].ToString();
            Applicant.phone = reader["phone"].ToString();
            Applicant.applicantAddress = reader["applicantAddress"].ToString();
            Applicant.email = reader["email"].ToString();
            Applicant.password = reader["pass"].ToString();
            Applicant.accountActivated = Int32.Parse(reader["accountActivated"].ToString());
            Applicant.activationCodeToken = reader["activationCodeToken"].ToString();
            //Applicant.userActivation = Int32.Parse(reader["userActivation"].ToString());
            
            //Check if the exam instance is activated
            DBService.ExamInstanceService service = new ExamInstanceService();
            ExamInstance instance = service.getExamInstanceByApplicantID(Applicant.applicantID);
            Applicant.userActivation = instance.active;
            
            return Applicant;

        }


        public List<Applicant> getAllApplicantsOfAdminClub(User adminUser)
        {
            List<Applicant> applicantsList = new List<Applicant>();

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {

                String query = "select  Applicant.username as applicantUSername,Applicant.email as applicantEmail, * from HuntingClub inner join UserTable  on HuntingClub.adminUserID = UserTable.userID "
                            + " inner join RegistrationRequests on HuntingClub.clubID = RegistrationRequests.clubID "
                            + "inner join Applicant on RegistrationRequests.applicantID = Applicant.applicantID "
                            + "where UserTable.userID ="+adminUser.userID;

                SqlDataReader reader = dbObj.selectQuery(query);


                while (reader.Read())
                {
                    Applicant app = fillApplicant(reader);
                    app.username = reader["applicantUSername"].ToString();
                    app.email = reader["applicantEmail"].ToString();
                    applicantsList.Add(app);
                }
            }
            dbObj.CloseConnection();
            return applicantsList;
        }

        public List<Applicant> getApplicants(int applicantID = 0)
        {
            List<Applicant> applicantsList = new List<Applicant>();

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String whereCond = "";
                if (!applicantID.Equals(0))
                {
                    whereCond = " WHERE applicantID = " + applicantID;
                }
                String query = "SELECT * FROM Applicant " + whereCond;

                SqlDataReader reader = dbObj.selectQuery(query);


                while (reader.Read())
                {
                    applicantsList.Add(fillApplicant(reader));
                }
            }
            dbObj.CloseConnection();
            return applicantsList;
        }

        public Boolean deleteApplicant(int ID)
        {
            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {

                String query = "Delete  FROM Applicant where applicantID="+ID;

                 dbObj.executeQuery(query);
              
            }
            dbObj.CloseConnection();
            return true;
        }

        public bool updateApplicant(Applicant applicant)
        {
            SQLClass dbObj = new SQLClass();

            SqlConnection conn = dbObj.openConnection();
            // add the insert between transaction and commit in order no to lose data integratiy ... 
            using (conn)
            {

                String query = "update  Applicant set username ='"+ applicant.username + "', "
                                +"firstname = N'" +  applicant.firstname + "'," 
                                +"middlename = N'" + applicant.middlename + "', " 
                                +"lastname  = N'"+ applicant.lastname + "', " 
                                +"gender ='" + applicant.gender + "', " 
                                +"dateOfBirth ='"+ applicant.dateOfBirth + "', " 
                                +"placeOfBirth = N'"+ applicant.placeOfBirth + "',"
                                +"registrationNb ='"+ applicant.registrationNb + "'," 
                                + "nationality = N'"+ applicant.nationality + "', " 
                                +"bloodType ='"+ applicant.bloodType + "',"
                                +"Profession = N'" + applicant.profession + "',"
                                +"email ='"+ applicant.email + "'," 
                                +"mailAddress = N'"+ applicant.mailAddress + "',"
                                + "fax ='" + applicant.fax + "',"
                                + "city = N'" + applicant.city + "',"
                                + "applicantAddress = N'" + applicant.applicantAddress + "',"
                                +"cellular ='"+applicant.cellular + "',"
                                + "phone ='" +applicant.phone + "' where applicantID ="+applicant.applicantID;
                                

             dbObj.executeQuery(query);
               
            }

            dbObj.CloseConnection();
            return true;
        }
    }
}