using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    
    문제
    
    코레스코 콘도미니엄 8층은 학생들이 3끼의 식사를 해결하는 공간이다. 
    그러나 몇몇 비양심적인 학생들의 만행으로 음식물이 통로 중간 중간에 떨어져 있다. 
    이러한 음식물들은 근처에 있는 것끼리 뭉치게 돼서 큰 음식물 쓰레기가 된다. 
    
    이 문제를 출제한 선생님은 개인적으로 이러한 음식물을 실내화에 묻히는 것을 정말 진정으로 싫어한다. 
    참고로 우리가 구해야 할 답은 이 문제를 낸 조교를 맞추는 것이 아니다. 
    
    통로에 떨어진 음식물을 피해가기란 쉬운 일이 아니다. 따라서 선생님은 떨어진 음식물 중에 제일 큰 음식물만은 피해 가려고 한다. 
    
    선생님을 도와 제일 큰 음식물의 크기를 구해서 “10ra"를 외치지 않게 도와주자.
    
    입력
    첫째 줄에 통로의 세로 길이 N(1 ≤ N ≤ 100)과 가로 길이 M(1 ≤ M ≤ 100) 그리고 음식물 쓰레기의 개수 K(1 ≤ K ≤ 10,000)이 주어진다.  그리고 다음 K개의 줄에 음식물이 떨어진 좌표 (r, c)가 주어진다.
    
    좌표 (r, c)의 r은 위에서부터, c는 왼쪽에서부터가 기준이다.
    
    출력
    첫째 줄에 음식물 중 가장 큰 음식물의 크기를 출력하라.
    
    예제 입력 1 
    3 4 5
    3 2
    2 2
    3 1
    2 3
    1 1
    
    예제 출력 1 
    4
    
    
    힌트
    # . . .
    . # # .
    # # . .
    
    위와 같이 음식물이 떨어져있고 제일큰 음식물의 크기는 4가 된다. (인접한 것은 붙어서 크게 된다고 나와 있음. 
    대각선으로는 음식물 끼리 붙을수 없고 상하좌우로만 붙을수 있다.) 
    

 */
namespace AvoidFoodTrash1743
{
    class Program
    {
        static int[,] matrix;//바닥 타일
        static int row;//행
        static int col;//열
        static int[,] coordinates = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };//상하좌우 dfs 를 위한것.
        static void Main(string[] args)
        {

            String[] inputs = Console.ReadLine().Split(' ');
            row = Int32.Parse(inputs[0]);//행
            col = Int32.Parse(inputs[1]);//열
            int count = Int32.Parse(inputs[2]);//음식물의 개수

            matrix = new int[row, col];//매트릭스 크기 정해줌

            for (int i = 0; i < count; i++)
            {
                String[] newInputs = Console.ReadLine().Split(' ');
                int x = Int32.Parse(newInputs[0]);
                int y = Int32.Parse(newInputs[1]);
                matrix[x - 1, y - 1] = 1;
            }

            int maxFoodCount = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int foodCount = dfs(matrix, i, j, 0);

                    maxFoodCount = Math.Max(foodCount, maxFoodCount);

                }
            }

            Console.WriteLine(maxFoodCount);

        }

        static int dfs(int[,] matrix, int inRow, int inCol, int foodCount)
        {
            if ( inRow >= row || inRow < 0 || inCol >= col || inCol < 0 || matrix[inRow, inCol] == 0)
            {
                return foodCount;
            }

            matrix[inRow, inCol] = 0;
            foodCount++;

            for (int i = 0; i < 4; i++)
            {
                foodCount = dfs(matrix, inRow + coordinates[i, 0], inCol + coordinates[i, 1], foodCount);
            }

            return foodCount;
        }
    }
}
