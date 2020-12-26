using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qoo10Work
{
    class Program
    {
        static void Main(string[] args)
        {

            TableCompare tc = new TableCompare();

            //List<String[]> stagingTable = tc.getStaging();//스테이징에 존재하는 테이블 정보
            //List<String[]> erdTable = tc.getErd();
            //List<String[]> stagingTableUp = tc.getStagingUpgrade(stagingTable);

            List<String[]> test = tc.getStaging();

            for (int i = 0; i < test.Count; i++)
            {
                for (int j = 0; j < test[i].Length; j++)
                {
                    Console.Write(test[i][j] + " ");
                }
                Console.WriteLine();
            }




            Console.ReadLine();
        }
    }
}
