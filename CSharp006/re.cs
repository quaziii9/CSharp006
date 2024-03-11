namespace CSharp006
{
    internal class re
    {
        //public delegate int MyDel(int a, int b);

        //static int Plus(int a, int b) { return a + b; }

        #region 계산기
        /*
        public delegate void TestDel(int a, int b);

        public static void SumNumber(int a, int b)
        {
            Console.WriteLine($"덧셈 : {a + b}");
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
        */
        #endregion

        //1.
        delegate void EventHandler(string str);

        class EventTest
        {   //2.
            public event EventHandler eve;

            public void func(int num)
            {
                int temp = num % 10;
                if (temp != 0 && temp % 3 == 0)
                {
                    // 3 ,6 ,9 로 끝날때마다 이벤트 발생
                    eve($"{num}");
                }
            }
        }

        //3.
        public static void MyHandler(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            //4.
            EventTest eventTest = new EventTest();
            eventTest.eve += new EventHandler(MyHandler);


            for (int i = 0; i < 30; i++)
            {
                //5.
                eventTest.func(i);
            }




            //MyDel callback = new MyDel(Plus);
            //MyDel callback2 = Plus; // 간략하게...
            //Console.WriteLine(callback(1, 2));
            //Console.WriteLine( callback2.Invoke(10, 20)); // invoke를 통해 참조되어 있는 함수를 호출  

            #region 계산기
            /*
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

            testDel.Invoke(a, b);
            */
            #endregion
        }
    }
}
