using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Data.DataProvider
{
    public interface IDataProvider
    {
        DataProvider GetInstance();
        DataProvider GetInstance(string connstr);
        DataTable Select(string sql);
        void Execute(string sql);
    }
}
