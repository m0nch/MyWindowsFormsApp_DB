using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Data.DataProvider
{
    public class SqlDataProvider : DataProvider, ISqlDataProvider
    {

        private string _connString;

        public SqlDataProvider(string strConn)
        {
            _connString = strConn;
        }

        public String GetConnString()
        {
            return _connString;
        }
        public SqlConnection GetConnection()
        {
            SqlConnection retval;

            try
            {
                retval = new SqlConnection(_connString);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid database connection string. " + ex.Message);
            };

            return retval;
        }

        public override DataTable Select(string sql)
        {
            SqlConnection conn;
            try
            {
                conn = GetConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot open database connection. " + ex.Message);
            };

            DataTable currTable = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                currTable = new DataTable();
                da.Fill(currTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot create SqlDataAdapter object. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return currTable;
        }

        public override void Execute(string sql)
        {
            SqlConnection conn;
            try
            {
                conn = GetConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot open database connection. " + ex.Message);
            };

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot execute. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
