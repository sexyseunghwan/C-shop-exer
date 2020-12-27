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

			List<String[]> stagingTable = tc.getStaging();//스테이징에 존재하는 테이블 정보
			List<String[]> erdTable = tc.getErd();
			List<String[]> stagingTableUp = tc.getStagingUpgrade(stagingTable);

			//확인용
			tc.tableCheck(stagingTableUp);
			//tc.tableCheck(stagingTable);
			System.Console.WriteLine("============");
			tc.tableCheck(erdTable);

			System.Console.WriteLine("++++++++++++++++++++++++++++++++");

			//비교
			ComparisonTable cst = new ComparisonTable();
			cst.comparisonTable(stagingTableUp, erdTable);

			Console.ReadLine();
        }
    }
}
