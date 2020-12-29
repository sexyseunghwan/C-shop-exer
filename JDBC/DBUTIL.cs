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
        private SqlConnection conn = null;

        public SqlConnection open(String host, String db, String id, String pw)
        {
            String ConnectionString = "Server=" + host + ";database=" + db + ";uid=" + id + ";pwd=" + pw + ";";


            try
            {
                conn.ConnectionString = ConnectionString;
                
                return conn;
            }
            catch(Exception e)
            {
                System.Console.WriteLine("접속 자체에 문제가 생김");
            }

            return null;
        }

        

    }
}
