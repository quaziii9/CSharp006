

namespace CSharp006
{
    //=============================================================
    // 델리게이트 체인 
    // 델리게이트 하나가 여러개의 메서드를 동시에 참조할 수 있음(차례대로)
    // +=, new...

    //=============================================================

    delegate void Student(string s);

    class Test
    {
        public void Print01(string str)
        {
            Console.WriteLine($"학생 {str}이/가 등교");
        }
        public void Print02(string str)
        {
            Console.WriteLine($"학생 {str}이/가 점심먹음");
        }
        public void Print03(string str)
        {
            Console.WriteLine($"학생 {str}이/가 집에감");
        }
    }

    internal class del2
    {
        // Invoke : 델리게이트에 등록된 메서드들을 순차적으로 실행시킨다.

        public delegate void TestDel(int a, int b);

        public static void  SumNumber(int a, int b)
        {
            Console.WriteLine($"덧셈 : {a+b}");
        }
        public static void MinNumber(int a, int b)
        {
            Console.WriteLine($"뺄셈 : {a - b}");
        }
        public static void MulNumber(int a, int b)
        { 
            Console.WriteLine($"곱셈 : {a * b}"); 
        }
        public static void DivNumber(int a, int b)
        {
            Console.WriteLine($"나눗셈 : {a / b}");
        }
        public static void RemNumber(int a, int b)
        {
            Console.WriteLine($"나머지 : {a % b}");
        }

        static void Main()
        {
            //Test t = new Test();
            //t.Print01("홍길동");

            //Student student = new Student(t.Print01);
            //t.Print02("홍길서");

            //student += t.Print02;
            //t.Print02("홍길남");
            //student += t.Print03;

            

            TestDel testDel = SumNumber;
            testDel += MinNumber; 
            testDel += MulNumber;
            testDel += DivNumber;
            testDel += RemNumber;

            int a = 0;
            int b = 0;
            Console.WriteLine("연산할 숫자를 입력하시오");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            testDel.Invoke(a,b);

            /*
             델리게이트 체인을 활용하여 계산기를 만들자
            
            */
        }
    }
}

