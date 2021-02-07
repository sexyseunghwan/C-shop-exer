using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingQueue1021
{

	class QueueList<T> : List<T>
	{

		private List<T> queueList = new List<T>();//Queue 생성시킴

        //왼쪽 시프트
        public void leftShift()
        {
			T picked = queueList[0];//여기 문제
			queueList.RemoveAt(0);
			queueList.Add(picked);
		}

		public void rightShift()
        {   
            T picked = queueList[queueList.Count - 1];
            queueList.RemoveAt(queueList.Count - 1);
            queueList.Insert(0, picked);
        }


	}

	class Program
	{

		static void Main(string[] args)
		{

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
                int pickNum = Int32.Parse(findNums[i]);//숫자
                Boolean flag = true;

                while(flag)
                {
                    int queueLength = queue.Count;//큐의 길이
                    int half = queueLength / 2;
                    int pointer = -1;//위치
                    //그냥 바로 찾는숫자가 앞에 있는 경우
                    if (queue[0] == pickNum) { queue.RemoveAt(0); flag = false; }
                    //찾는 숫자가 앞에 없는 경우
                    else
                    {
                        
                        //어느 위치에 있는지 확인
                        for (int j = 0; j < queueLength; j++)
                        {
                            if (queue[j] == pickNum) { pointer = j; break; }

                        }//for

                        System.Console.WriteLine(pointer);

                        if (pointer > half) { queue.rightShift(); answerCount++; }
                        else { queue.leftShift(); answerCount++; }//여기 문제
                    }

                }
            }//for




            System.Console.WriteLine(answerCount);
            ////System.Console.WriteLine(count);
            //System.Console.ReadLine();

        }
	}
}