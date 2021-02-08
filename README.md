# C-shop-exer


String input = System.Console.ReadLine();//10 3

			int endNumber = Int32.Parse(input.Split(' ')[0]);// 1 ~ endNumber 까지의 숫자
			int count = Int32.Parse(input.Split(' ')[1]);//몇개의 숫자를 뽑을 것인지

			//System.Console.WriteLine(endNumber);//확인
			//System.Console.WriteLine(count);//확인

			int answerCount = 0;//답으로 도출할것이다.

			QueueList<int> queue = new QueueList<int>();//큐 역할을 수행하는 리스트를 생성 -> 상속 클래스 생성

			for (int i = 0; i < endNumber; i++)
			{
				queue.Add(i + 1);
			}

			String[] findNums = System.Console.ReadLine().Split(' ');//찾을 숫자를 입력받는곳

			for (int i = 0; i < count; i++)
			{
				int pickNum = Int32.Parse(findNums[i]);//찾을 숫자
				Boolean flag = true;
				int queueLength = queue.Count;//큐의 길이
				int half = queueLength / 2;
				int pointer = -1;//찾을 숫자의 위치
								 //어느 위치에 있는지 확인
				for (int j = 0; j < queueLength; j++)
				{
					if (queue[j] == pickNum) { pointer = j; break; }

				}//for

				while (flag)
				{
					if (queue[0] == pickNum) { queue.RemoveAt(0); flag = false; }
					else
					{
						if (pointer > half)
						{
							queue.rightShift();
							answerCount++;

						}
						else
						{
							queue.leftShift();
							answerCount++;
						}//문제

					}
				}


			}//for

			System.Console.WriteLine(answerCount);
}
