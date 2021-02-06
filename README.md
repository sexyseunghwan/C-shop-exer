# C-shop-exer


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schemamaster
{

	class QueueList<T> : List<T>
	{

		private List<T> queueList = new List<T>();//생성시킴

		//enqueue 의 역할을 수행한다.
		public void enQueue(T obj) {
			queueList.Add(obj);
		} 

		//dequeue 의 역할을 수행한다.
		public T deQueue(){
			T t = queueList[0];
			queueList.RemoveAt(0);
			return t;
		}
		
		
	}

	class Program
	{

		

		static void Main(string[] args)
		{

			//Menu menu = new Menu();//기본메뉴 구성
			//menu.menuOut();

			String input = System.Console.ReadLine();

			int endNumber = Int32.Parse(input.Split(' ')[0]);// 1 ~ endNumber 까지의 숫자
			int count = Int32.Parse(input.Split(' ')[1]);//몇개의 숫자를 뽑을 것인지
			
			//int[] intArr = new int[count];//어떤 숫자들을 뽑을건지 리스트화 시킨다.

			
			QueueList<int> queue = new QueueList<int>();//큐 역할을 수행하는 리스트를 생성

			for (int i = 0; i < endNumber; i++) {
				queue.enQueue(i + 1);
			}

			//여기서부터 동작을 시작해야하는데...
			String[] findNums = System.Console.ReadLine().Split(' ');//찾을 숫자를 입력받는곳

			for (int i = 0; i < count; i++)
			{
				int pickNum = Int32.Parse(findNums[i]);//숫자
				int queueLength = queue.Count;
				int half = queueLength / 2;
				int pointer = -1;//위치

				//어느 위치에 있는지 확인
				for (int j = 0; j < queueLength; j++) {

					if (queue[j] == pickNum) {
						pointer = j;
						break;
					}
	
				}//for

				if (pointer > half) {
					Boolean flag = true;
					
					while(flag) {
						//int num =
						
					}

				} else {

				}


			}//for




			System.Console.WriteLine(endNumber);
			System.Console.WriteLine(count);


			System.Console.ReadLine();

		}
	}
}
