using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalWarming5212
{
    class Program
    {
		static String[,] answerMatrix;
		static String[,] inputMatrix;
		static void Main(string[] args)
        {
			String[] inputs = Console.ReadLine().Split(' ');

			int row = Int32.Parse(inputs[0]);//생성될 행
			int col = Int32.Parse(inputs[1]);//생성될 열
			
			answerMatrix = new String[row + 2, col + 2];
			inputMatrix = new string[row + 2, col + 2];

			//비교 배열과 정답배열을 따로 만들어준다.
			for (int i = 0; i < row + 2; i++)
			{
				for (int j = 0; j < col + 2; j++)
				{
					answerMatrix[i, j] = ".";
					inputMatrix[i, j] = ".";
				}
			}
			
			//비교배열을 생성한다. -> 사용자에게 입력받는다.
			for (int i = 1; i < row + 1; i++)
			{
				String inputsToken = Console.ReadLine();
				for (int j = 1; j < col + 1; j++)
				{
					inputMatrix[i, j] = inputsToken.Substring(j-1,1);
				}
			}
			//아니 런타임에러가 왜나는건데
			//깊이탐색을 시작.
			for (int i = 1; i < row + 1; i++)
            {
				for (int j = 1; j < col + 1; j++)
                {
					dfs(i, j);
				}
            }

            int rstart = answerCheckAsc(row, col, 1);
            int rlast = answerCheckDesc(row, col, 1);
            int cstart = answerCheckAsc(col, row, 0);
            int clast = answerCheckDesc(col, row, 0);


            //확인하는 곳
            for (int i = rstart; i <= rlast; i++)
            {
                for (int j = cstart; j <= clast; j++)
                {
                    Console.Write(answerMatrix[i, j]);
                }
                Console.WriteLine();
            }

			//Console.ReadLine();
			//런타임 에러가 왜 나는지 모르곘는데 진짜 짜증난다
        }

		static int answerCheckAsc(int index1, int index2, int select)
        {
			int answerIndex = 0;
			
			for (int i = 1; i < index1 + 1; i++)
			{
				bool flag = true;
				for (int j = 1; j < index2 + 1; j++)
				{
					if (select == 1)
					{
						if (answerMatrix[i,j].Equals("X"))
						{
							flag = false;
							answerIndex = i;
							break;
						}
					}
					else
					{
						if (answerMatrix[j,i].Equals("X"))
						{
							flag = false;
							answerIndex = i;
							break;
						}
					}
				}
				if (!flag) break;
			}
			return answerIndex;
		}

		static int answerCheckDesc(int index1, int index2, int select)
		{
			int answerIndex = 0;

			for (int i = index1 + 1; i >= 1; i--)
			{
				bool flag = true;
				for (int j = 1; j < index2 + 1; j++)
				{
					if (select == 1)
					{
						if (answerMatrix[i, j].Equals("X"))
						{
							flag = false;
							answerIndex = i;
							break;
						}
					}
					else
					{
						if (answerMatrix[j, i].Equals("X"))
						{
							flag = false;
							answerIndex = i;
							break;
						}
					}
				}
				if (!flag) break;
			}
			return answerIndex;
		}


		static void dfs(int x, int y)
        {
			if (inputMatrix[x, y].Equals(".")) return;

			int cnt = 0;
			
			if (inputMatrix[x - 1, y].Equals(".")) cnt++;
			if (inputMatrix[x , y - 1].Equals(".")) cnt++;
			if (inputMatrix[x + 1, y].Equals(".")) cnt++;
			if (inputMatrix[x , y + 1].Equals(".")) cnt++;

			if (cnt >= 3) {
				answerMatrix[x, y] = ".";
			} else
            {
				answerMatrix[x, y] = "X";
			}
		}
    }
}
