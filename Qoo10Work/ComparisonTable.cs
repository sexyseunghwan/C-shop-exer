using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qoo10Work
{
    class ComparisonTable
    {
		//ERD table 과 Stg 테이블의 본격적인 비교
		public void comparisonTable(List<String[]> stgList, List<String[]> erdList)
		{

			int stgSize = stgList.Count;//스테이징에 있는 테이블 컬럼 개수
			int erdSize = erdList.Count;//erd에 있는 테이블 컬럼개수

			if (stgSize > erdSize)
			{
				//staging 에 있는 테이블이 erd 에 있는 테이블보다 컬럼 개수가 많은 경우
				bigTable(stgList, erdList, "staging");

			}
			else if (stgSize < erdSize)
			{
				//staging 에 있는 테이블이 erd 에 있는 테이블보다 컬럼 개수가 적은경우
				bigTable(erdList, stgList, "erd");

			}
			else
			{
				//staging 에 있는 테이블과 erd 에 있는 테이블의 컬럼 개수가 같은 경우
				tableEquals(stgList, erdList);

			}
		}//comparisonTable()


		public void tableEquals(List<String[]> stgList, List<String[]> erdList)
		{
			//테이블의 컬럼 개수가 같은 경우 --> 이부분이 생각해 줄게 엄청 많은 부분이다.
			//List<String> errArr = new ArrayList<String>();//에러 컬럼명 넣어줄 것이다. 기준은 staging 을 기준으로 한다.

			//1. staging => erd
			int result1 = stgToErd(stgList, erdList);

			//2. erd => staging
			int result2 = erdToStg(stgList, erdList);

			//3. staging <=> erd
			if (result1 == 0 && result2 == 0)
			{
				//둘다 문제가 없는 경우 -> 이제 진짜 여기서 staging 과 erd 를 비교할 것이다.
				int finalResult = equivalent(stgList, erdList);

				if (finalResult == 0)
				{
					//문제 없는경우
					System.Console.WriteLine("ERD STAGING 모두 동치");
				}
			}

		}//tableEquals()

		public int equivalent(List<String[]> stgList, List<String[]> erdList)
		{
			// srg <=> erd
			List<String> errArr = new List<String>();

			int result = 0;//0일때는 문제없음

			for (int i = 0; i < stgList.Count; i++)
			{
				String[] stgArr = stgList[i];

				String word = "";

				String stgName = stgArr[0];
				String stgType = stgArr[1];
				String stgNull = stgArr[2];

				//int typeNum = 0;//0 : 문제없음, 1 : 타입이나 null이 맞지않음

				for (int j = 0; j < erdList.Count; j++)
				{

					String[] erdArr = erdList[j];

					String erdName = erdArr[0];
					String erdType = erdArr[1];
					String erdNull = erdArr[2];

					if (stgName.Equals(erdName))
					{
						if (stgType.Equals(erdType) && stgNull.Equals(erdNull))
						{
							//나머지 형도 모두 같은 경우
							break;
						}
						else
						{
							//타입이나 null이 맞지 않은경우
							//typeNum = 1;
							result = 1;
							word = String.Format("[ERD] {0} {1} {2} => [STG] {3} {4} {5}", erdName, erdType, erdNull, stgName, stgType, stgNull);
							errArr.Add(word);
							break;
						}
					}
				}//for
			}//for

			if (result != 0)
			{

				System.Console.WriteLine("*******************");
				for (int i = 0; i < errArr.Count; i++)
				{
					System.Console.WriteLine(errArr[i]);
				}
				System.Console.WriteLine("*******************");

			}

			return result;

		}//equivalent()


		public int erdToStg(List<String[]> stgList, List<String[]> erdList)
		{
			//erd => stg

			List<String[]> errArr = new List<String[]>();//에러 컬럼명 넣어줄 것이다.

			int result = 0;//문제가 없는경우 0 이 반환 문제가 존재하면 1이 반환

			for (int i = 0; i < erdList.Count; i++)
			{
				String[] erdArr = erdList[i];
				String erdName = erdArr[0];

				Boolean flag = false;

				for (int j = 0; j < stgList.Count; j++)
				{
					String[] stgArr = stgList[j];

					String stgName = stgArr[0];

					if (erdName.Equals(stgName))
					{
						flag = true;
						break;
					}
				}//for

				if (!flag)
				{
					//staging 에 있는 컬럼이 없는경우
					errArr.Add(erdArr);
					result = 1;
				}

			}//for

			if (errArr.Count != 0)
			{
				//문제가 있는경우
				System.Console.WriteLine("*******************");
				System.Console.WriteLine("erdTo 문제가 존재하는 컬럼 개수 : " + errArr.Count);
				System.Console.WriteLine("=== erd 에는 있지만 stg 에는 없는 컬럼이름 리스트 ===");

				for (int i = 0; i < errArr.Count; i++)
				{
					for (int j = 0; j < errArr[i].Length; j++)
					{
						System.Console.Write(errArr[i][j] + " ");
					}
					System.Console.WriteLine();
				}

				System.Console.WriteLine("*******************");
			}

			return result;

		}//erdToStg()

		public int stgToErd(List<String[]> stgList, List<String[]> erdList)
		{

			//stg => erd

			List<String[]> errArr = new List<String[]>();//에러 컬럼명 넣어줄 것이다.

			int result = 0;//문제 없을 경우 0 문제있는경우 1



			for (int i = 0; i < stgList.Count; i++)
			{
				String[] stgArr = stgList[i];
				String stgName = stgArr[0];

				Boolean flag = false;

				for (int j = 0; j < erdList.Count; j++)
				{
					String[] erdArr = erdList[j];

					String erdName = erdArr[0];

					if (stgName.Equals(erdName))
					{
						flag = true;
						break;
					}
				}//for

				if (!flag)
				{
					//staging 에 있는 컬럼이 없는경우
					errArr.Add(stgArr);
					result = 1;
				}

			}//for

			if (errArr.Count != 0)
			{
				//문제가 있는경우 
				System.Console.WriteLine("*******************");
				System.Console.WriteLine("stagingTo 문제가 존재하는 컬럼 개수 : " + errArr.Count);
				System.Console.WriteLine("=== staging 에는 있지만 erd 에는 없는 컬럼이름 리스트 ===");

				for (int i = 0; i < errArr.Count; i++)
				{
					for (int j = 0; j < errArr[i].Length; j++)
					{
						System.Console.Write(errArr[i][j] + " ");
					}
					System.Console.WriteLine();
				}
				System.Console.WriteLine("*******************");
			}

			return result;

		}//stgToErd()

		public void bigTable(List<String[]> bigList, List<String[]> smallList, String db)
		{

			List<String[]> errArr = new List<String[]>();//에러 컬럼명 넣어줄 것이다.

			for (int i = 0; i < bigList.Count; i++)
			{

				String[] bigArr = bigList[i];//stg 컬럼
				String bigName = bigArr[0];

				Boolean flag = false;

				for (int j = 0; j < smallList.Count; j++)
				{

					String smallName = smallList[j][0];

					if (bigName.Equals(smallName))
					{
						flag = true;
						break;
					}
				}

				if (!flag)
				{
					//staging 에 있는게 없다는 의미 아니면 잘못됬다는 의미가 된다.
					errArr.Add(bigArr);
				}
			}//for

			System.Console.WriteLine("=========================");
			System.Console.WriteLine(db + " 에 컬럼개수가 더 많음");

			for (int i = 0; i < errArr.Count; i++)
			{
				for (int j = 0; j < errArr[i].Length; j++)
				{
					System.Console.Write(errArr[i][j] + " ");
				}
				System.Console.WriteLine(" 누락");
			}


		}//bigTable()

	}
}
