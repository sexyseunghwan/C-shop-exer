using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{

    class Program
    {
        delegate int Mydel1(int a, int b);//delegate 선언을 해준다. -> 원하는 양식에 맞추어 선언을 해줘야한다 : 함수형 포인터라고 생각하면 된다.
        delegate T Mydel2<T>(T a, T b);//제네릭을 통한 delegate 사용법

        static void Main(string[] args)
        {

            //m1();
            m2();
            Console.ReadLine();

        }

        public static void m1()
        {
            //기본적인 delegate의 사용방법
            Calculator c1 = new Calculator();//클래스 생성
            
            //static으로 관리하기도 하지만.. 프로젝트를 직접 수행하게 되면  static은 지양하므로 class 를 직접만들어줘서 사용하는걸 권장한다.
            Mydel1 del1 = new Mydel1(c1.sum);//함수포인터와 같은 역할을 수행 c1.sum() 을  del1 이 대신 수행한다고 할수 있다.

            Console.WriteLine(del1(10, 20));
        }

        public static void m2()
        {
            //제네릭을 통한 delegate 의 사용법
            GenericCal gc = new GenericCal();

            //이런식으로 직접 제네릭을 통해서 delegate 를 사용할 수 있다.
            Mydel2<int> plus_int = new Mydel2<int>(gc.sum);
            Mydel2<float> plus_float = new Mydel2<float>(gc.sum);
            Mydel2<double> plus_double = new Mydel2<double>(gc.sum);


            Console.WriteLine("13 + 13 = " + plus_int(13,13));
            Console.WriteLine("13.4 + 13.5 = " + plus_float(13.4f, 13.5f));
            Console.WriteLine("13.75 + 13.84 = " + plus_double(13.75, 13.84));

            Console.ReadLine();

        }

    }
    
    class GenericCal
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
        public float sum(float a, float b)
        {
            return a + b;
        }

        public double sum(double a, double b)
        {
            return a + b;
        }
    }


    class Calculator
    {
        public int sum(int a, int b)
        {
            return a + b;
        }

        public int minus(int a, int b)
        {
            return a - b;
        }
    }
}
