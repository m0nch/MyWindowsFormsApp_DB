using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Data.DataProvider
{
    public class DataProvider : IDataProvider
    {
        public static string connectionString = "Server = DATA_SERVER; Database=University; User Id = sa; Password=sa12345^";
        public DataProvider GetInstance()
        {
            return new SqlDataProvider(connectionString);
        }

        public DataProvider GetInstance(string connstr)
        {
            return new SqlDataProvider(connstr);
        }
        public virtual DataTable Select(string sql)
        {
            throw new Exception();
        }
        public virtual void Execute(string sql) 
        {
            throw new Exception();
        }
    }
}
