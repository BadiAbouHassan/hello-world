using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class HuntingClubService
    {
        public HuntingClubService()
        {
        }

        /// <summary>
        /// insert new hunting club
        /// </summary>
        /// <param name="club"></param>
        /// <returns></returns>
        public Boolean add(HuntingClub club)
        {
            Boolean result;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into HuntingClub(clubname, clubAddress,phoneNb,email) values('"
                                + club.clubName + "','" + club.clubAddress + "','" + club.phoneNb + "','" + club.email + "');";

               result= dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }

        /// <summary>
        /// return list of hunting clubs
        /// </summary>
        /// <returns></returns>

        public List<HuntingClub> getClubs()
        {
            List<HuntingClub> clubList = new List<HuntingClub>();

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from HuntingClub";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    HuntingClub club = fillHuntingClub(reader);
                    clubList.Add(club);

                }


            }
            dbObj.CloseConnection();
            return clubList;
        }

        /// <summary>
        /// fill club object fromsqldatareader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private HuntingClub fillHuntingClub(SqlDataReader reader)
        {
            HuntingClub club = new HuntingClub();
            club.clubName = reader["clubname"].ToString();
            club.clubAddress = reader["clubAddress"].ToString();
            club.clubID = Int32.Parse(reader["ID"].ToString());
            club.email = reader["email"].ToString();
            return club;
        }


    }
}