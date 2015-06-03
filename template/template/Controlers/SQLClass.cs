using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace template.Controlers
{
    //this class is the main class for databSE CONNECTION
    public class SQLClass : IDisposable
    {
        public SqlConnection connection;
        public SQLClass dbObj;

        public SQLClass()
        {
            
        }
         /// <summary>
        ///  this function open a connection to the databse that have been created before.. 
        /// </summary>
        /// <param name="dbobj"></param>
        public SqlConnection openConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mainConnection"].ToString());
            this.connection = connection;
            this.connection.Open();
            return this.connection;
        }

        /// <summary>
        /// this function execute a query of type insert, update , delete, create query .. 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Boolean executeQuery(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, this.connection);
            int row_affected = cmd.ExecuteNonQuery();
            if (row_affected == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// this function return an array that containe all the result of the query 
        /// select ... 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader selectQuery(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, this.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public void CloseConnection()
        {
            this.connection.Close();
        }
     
 
        public void Dispose()
        {
            CloseConnection();
            connection.Dispose();
        }
    }
}