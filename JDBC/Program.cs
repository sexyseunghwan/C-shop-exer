using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace JDBC
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("asd");

            DBUTIL util = new DBUTIL();
            SqlConnection conn = null;

            try
            {
                conn = util.open("192.168.35.93", "11289", "ADMIN","byeanma","java1234");

                //SqlCommand scom = new SqlCommand();

                //scom.Connection = conn;

                //그냥 기본적인 SELECT 문
                //scom.CommandText = "SELECT name,city FROM dbo.TBLINSA";

                //SqlDataReader sdr = scom.ExecuteReader();

                //while(sdr.Read())
                //{
                //    Console.WriteLine("이름 : {0}, 사는 곳 : {1}",sdr["name"].ToString(), sdr["city"].ToString());
                //}

                //프로시저 호출
                SqlCommand scom = new SqlCommand("sh_test1", conn);
                scom.CommandType = CommandType.StoredProcedure;

                SqlParameter pinput = new SqlParameter("@buseo", System.Data.SqlDbType.VarChar);
                pinput.Direction = ParameterDirection.Input;
                pinput.Value = "개발부";
                scom.Parameters.Add(pinput);

                SqlDataReader sdr = scom.ExecuteReader();

                while (sdr.Read())
                {
                    Console.WriteLine("이름 : {0} 부서 : {1} 직위 : {2}", sdr["name"].ToString(), sdr["buseo"].ToString(), sdr["jikwi"].ToString());
                    
                }

                //뭐 이정도는 쉬운데

                conn.Close();//객체 닫아주기

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                System.Console.WriteLine("문제");
            }

            
            System.Console.ReadLine();

        }
    }
}
