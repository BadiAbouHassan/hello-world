using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class CountryService
    {
        public CountryService()
        {
        }

        public List<Country> getCountries()
        {
            List<Country> List = new List<Country>();

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {

                String query = "select * from Country ";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    Country c = fillCountry(reader);
                    List.Add(c);

                }


            }
            dbObj.CloseConnection();
            return List;
        }

        public DataSet getCountriesDataSet()
        {
            SQLClass dbObj = new SQLClass();
            DataSet ds = new DataSet();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from Country ";
                SqlDataAdapter myCommand = new SqlDataAdapter(query, cn);
                myCommand.Fill(ds, "Country");
            }
            dbObj.CloseConnection();
            return ds;
        }

        public Country getCountryByCode(String Code)
        {
            Country country = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Country where countryCode= '" + Code + "'";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    country = fillCountry(reader);
                }
            }

            dbObj.CloseConnection();
            return country;
        }

        private Country fillCountry(SqlDataReader reader)
        {
            Country c = new Country();
            c.countryID = Int32.Parse(reader["countryID"].ToString());
            c.countryCode = reader["countryCode"].ToString();
            c.countryName = reader["countryName"].ToString();
            c.countryNameAr = reader["countryNameAr"].ToString();
            return c;
        }


    }
}