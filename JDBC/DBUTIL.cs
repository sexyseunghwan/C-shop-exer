using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JDBC
{
    class DBUTIL
    {
        private SqlConnection conn;

        public SqlConnection open(String host,String port, String db, String id, String pw)
        {
            String ConnectionString = "Server=" + host + "," + port +";database=" + db + ";uid=" + id + ";pwd=" + pw + ";";
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();

                return conn;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                System.Console.WriteLine("접속 자체에 문제가 생김");
            }

            return null;
        }
    }
}
