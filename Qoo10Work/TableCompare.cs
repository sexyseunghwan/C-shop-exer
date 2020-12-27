using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Qoo10Work
{
    class TableCompare
    {

		//스테이징에 존재하는 테이블의 정보를 빼오는것
		public List<String[]> getStaging()
        {   
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\test\staging.txt");

            String line = null;

			List<String[]> staging = new List<String[]>();
			Regex regex = new Regex(@"^[a-zA-Z0-9]$");//정규식 표현 써줄것이다.

			while ((line = file.ReadLine()) != null)
            {
                String[] inputs = new String[4];//이름,형,크기,null 유무

                String voca = "";//단어
                int index = 0;//인덱스

				for (int i = 0; i < line.Length; i++)
				{

					String word = line.Substring(i,1);

					if (i == line.Length - 1)
					{
						voca += word;
						inputs[index] = voca;
					}
					else
					{
						//마지막 단어가 아닐 경우에
						if (!regex.IsMatch(word) && (!word.Equals("_")) && (!word.Equals("-")))
						{

							if (!voca.Equals(""))
							{
								inputs[index] = voca;
								index++;
							}
							
							voca = "";
						}
						else
						{
							voca += word;
						}
					}

				}//for

				staging.Add(inputs);

			}//while
            return staging;
		}//getStaging()

		//staging 테이블 가공작업 -> ERD 테이블의 정보와 비교가능하게끔 바꿔준다.
		public List<String[]> getStagingUpgrade(List<String[]> stgErd) 
		{

			List<String[]> stgNewArr = new List<String[]>();//새롭게 바뀔 리스트

			for (int i = 0; i < stgErd.Count; i++)
			{

				String[] stgArr = new String[3];//컬럼이름,형(크기),nullable
				String[] oldTbl = stgErd[i];//기존 테이블 컬럼 원소집합


				String name = oldTbl[0].ToLower().Trim();//컬럼 이름
				String type = oldTbl[1].ToLower().Trim();//타입
				String size = oldTbl[2].ToLower().Trim();//컬럼 사이즈
				String nullable = oldTbl[3].ToLower().Trim();//null 허용 유무

				String typeSize = "";//새롭게 집어넣을 것이다.

				if (type.Contains("char"))
				{
					//char 이 들어갔을 경우에

					if (size.Equals("-1"))
					{
						//사이즈가 -1 일 경우에
						typeSize = type + "(max)";
					}
					else
					{
						//사이즈가 -1이 아닐 경우에

						if (type.Contains("n"))
						{
							//유니코드 문자열일 경우에 -> 나누기 2를 해줄것이다.
							int sizeComp = Int32.Parse(size) / 2;

							typeSize = type + "(" + sizeComp + ")";
						}
						else
						{
							//유니코드 문자열이 아닐 경우에
							typeSize = type + "(" + size + ")";
						}

					}
				}
				else
				{
					//괄호가 의미가 없는 경우 -> 문자형이 아닌타입들에 대해서 처리
					typeSize = type;
				}

				stgArr[0] = name;
				stgArr[1] = typeSize;
				stgArr[2] = nullable;

				stgNewArr.Add(stgArr);


			}//for

			return stgNewArr;

		}//getStagingUpgrade()

		//ERD 에 존재하는 테이블 정보
		public List<String[]> getErd()
        {
			System.IO.StreamReader readerErd = new System.IO.StreamReader(@"C:\test\erd.txt");

			String line = null;

			List<String[]> erdArr = new List<String[]>();

			String[] inputErd = new String[3];//이름,형(크기),null 유무
			int indexErd = 0;

			while ((line = readerErd.ReadLine()) != null)
            {
				
				line = line.ToLower().Trim();

				if (indexErd == 2)
                {
					if (line.Equals("not null") || line.Equals("identity"))
                    {
						inputErd[indexErd] = "no";
                    } else
                    {
						inputErd[indexErd] = "yes";
					}

					erdArr.Add(inputErd);
					indexErd = 0;
					inputErd = new String[3];

                } else
                {
					inputErd[indexErd] = line;
					indexErd++;
                }

			}//while

			return erdArr;
		}

		//각 테이블의 정보를 확인시켜주는 메소드
		public void tableCheck(List<String[]> inputArr)
        {
			int outLength = inputArr.Count;//전체 크기
			int innerLength = inputArr[0].Length;// 한 요소의 크기


			for (int i = 0; i < outLength; i++)
			{
				for (int j = 0; j < innerLength; j++)
				{
					System.Console.Write(inputArr[i][j] + " ");
				}
				System.Console.WriteLine();
			}
		}


	}
}
