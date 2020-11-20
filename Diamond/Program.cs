using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingQueue1021
{
	class Program
	{
		static void Main(string[] args)
		{

			int totalCount = 0;//쉬프트연산 몇번일어났는지 카운트

			String[] input = Console.ReadLine().Split(' ');
			int queueSize = Int32.Parse(input[0]);
			int pick = Int32.Parse(input[1]);

			String[] inputNum = Console.ReadLine().Split(' ');

			int insIndex = 0;// 숫자배열 인덱스 지정

			List<int> queue = new List<int>();//queue를 쓰지 않고 List 형식을 사용함.

			for (int i = 0; i < queueSize; i++)
			{
				queue.Add(i + 1);
			}

			while (insIndex < inputNum.Count())
			{
				//숫자배열의 크기가 0 이되면 루프문을 멈추겠다
				int stdNum = Int32.Parse(inputNum[insIndex]);//기준이 되는 숫자.

				if (stdNum == queue[0])
				{
					queue.RemoveAt(0);
				}
				else
				{
					//여기서 이제 왼쪽쉬프트를 진행할건지 오른쪽 쉬프트를 진행할건지 기준을 잡아주면 된다.
					int size = queue.Count() / 2;
					int numIndex = 0;

					for(int i = 0; i < queue.Count(); i++) {
						if (queue[i] == stdNum) { numIndex = i; break; } 
					}//여기서 몇번째 인덱스에 숫자가 들어있는지 확인해준다.
					
					if (numIndex <= size) {
						//왼쪽 시프트
						
						while(queue[0] != stdNum) {
							queue.Add(queue[0]);
							queue.RemoveAt(0);
							totalCount++;
						}

						queue.RemoveAt(0);

					} else {
						//오른쪽 시프트

						while (queue[0] != stdNum)
						{
							int temp = queue[queue.Count() - 1];//마지막 숫자 넣기
							for (int j = queue.Count() - 2; j >= 0; j--) {
								queue[j + 1] = queue[j];
							}
							queue[0] = temp;
							totalCount++;
						}

						queue.RemoveAt(0);
					}
				}
				insIndex++;
			}

			Console.WriteLine(totalCount);//정답출력

			Console.ReadLine();

		}
	}
}
