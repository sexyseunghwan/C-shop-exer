using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        { 
            

            int input = Int32.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < input; i++)
            {
                Stack<String> stack = new Stack<String>();
                String inputs = Console.ReadLine();

                for (int j = 0; j < inputs.Count(); j++)
                {
                    //String top = stack.Peek();
                    if (stack.Peek() == inputs)
                }


            }



            Console.ReadLine();
            
            

        }

        
    }
}
