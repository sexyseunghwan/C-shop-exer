using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JDBC
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUTIL util = new DBUTIL();
            SqlConnection conn = null;

            try
            {
                conn = util.open("localhost","ADMIN","sa","java1234");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                System.Console.WriteLine("문제");
            }



        }
    }
}
