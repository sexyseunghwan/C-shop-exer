# C-shop-exer







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{	
	class Program
	{
		static String[,] answerMatrix;

		static void Main(string[] args)
		{
			
			String[] inputs = Console.ReadLine().Split(' ');

			int row = Int32.Parse(inputs[0]);//생성될 행
			int col = Int32.Parse(inputs[1]);//생성될 열

			answerMatrix = new String[row + 2, col + 2];
			String[,] inputMatrix = new string[row + 2, col + 2];
			
			for (int i = 0; i < row + 2; i++) {
				for (int j = 0; j < col + 2; j++) {
					answerMatrix[i,j] = ".";
				}
			}
			//여기서 문제가 생기네....
			for (int i = 1; i < row + 1; i++) {
				String[] inputsToken = Console.ReadLine().Split(' ');
				for (int j = 1; j < col + 1; j++) {
					inputMatrix[i, j] = inputsToken[j - 1];
				}
			}

			//확인하는 곳
			for (int i = 0; i < row + 2; i++)
			{
				for (int j = 0; j < col + 2; j++)
				{
					Console.Write(inputMatrix[i, j]);

				}
				Console.WriteLine();
			}


			Console.ReadLine();


			



		}
	}
}

