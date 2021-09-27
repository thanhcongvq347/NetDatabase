using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace _18103013_BaiTap03
{
   public class DataService
    {
        string connectstring;
        public DataService(string connectstring)
        {
            this.connectstring = connectstring;
        }
        public bool KiemTraServer(string connectstring)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectstring);
                connect.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataSet LayDuLieu(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, connectstring);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }
    }
}