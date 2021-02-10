# C-shop-exer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schemamaster
{

	class Program
	{
		static void Main(string[] args)
		{
			
			int numCount = Int32.Parse(System.Console.ReadLine());
			int[] arr = new int[numCount];

			String[] nums = System.Console.ReadLine().Split(' ');
			
			for (int i = 0; i < numCount; i++) {
				arr[i] = Int32.Parse(nums[i]);
			}

			int tryCount = Int32.Parse(System.Console.ReadLine());

			System.Console.WriteLine("**" + tryCount);

			for (int i = 0; i < tryCount; i++) {
				String[] inputs = System.Console.ReadLine().Split(' ');

				int first = Int32.Parse(inputs[0]);
				int second = Int32.Parse(inputs[1]);
				int third = Int32.Parse(inputs[2]);

				if (first == 1) {

					arr[second - 1] = arr[third - 1];
					
				} else {

					int minNum = int.MaxValue;

					for (int j = second - 1; j < third; i++)
					{
						minNum = arr[j] < minNum ? arr[j] : minNum;//?
					}

					System.Console.WriteLine(minNum);


				}
			}



			System.Console.ReadLine();
	
		}
	}
}
