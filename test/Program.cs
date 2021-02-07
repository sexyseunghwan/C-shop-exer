using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> arr = new List<int>();

            arr.Add(1);
            arr.Add(3);
            arr.Add(2);
            arr.Add(5);

            arr.RemoveAt(0);
            arr.Insert(0, 11);


            for (int i = 0; i < arr.Count; i++)
            {
                System.Console.WriteLine(arr[i]);
            }

        }
    }
}
