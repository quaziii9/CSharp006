
namespace CSharp006
{
    internal class de1
    {
        //===========================================================================
        // 델리게이트 (콜백) : 실행된 시점에 부여하는 식 , 누군가를 대신해서 일해주는 
        // 매서드의 참조 ,
        // 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
        // 대리자 인스턴스를 통해 함수를 호출할 수 있음 
        // 델리게이트는 메소드에 대한 참조
        // 델리게이트에 메소드의 주소를 할당한후 델리게이트를 호출하면 
        // 이 델리게이트가 메소드르 호출해준다.
        // 델리 게이트는 메소드에 대한 참조이기 대문에 자신이 참조할 반환 형식과 매개변수를 명시
        // <정의>
        // 한정자 delegatae int 델리게이트 이름(매개변수...)
        //===========================================================================
        // 요약 
        // 1. 델리게이트를 선언
        // 2. 선언한 델리게이트가 참조할 메서드를 선언
        // 3. 델리게이트의 인스턴스를 만들고 델리게이트가 참조할 메서드를 매개변수로 넘긴다.
        // 4. 델리게이트 호출

        public delegate int MyDel(int a, int b);

        public delegate int MyDel2(string str);

        static int Plus(int a, int b)
        {
            return a + b;
        }
        static int Minus(int a , int b)
        {
            return a - b;
        }
        
        static void Message(string msg) { Console.WriteLine(msg); }

        static void Main()
        {
            MyDel callback;
            callback = new MyDel(Plus);
            Console.WriteLine(callback(1, 2));
            callback.Invoke(10, 20); // invoke를 통해 참조되어 있는 함수를 호출
            MyDel callback2 = Minus; // 간략하게...
            // 실행 -> 호출 -> return

            MyDel2 StrDel;

            // StrDel = Minus; // error : 반환형과 매개변수가 일치하지 않는 함수면 참조불가

        }
    }
}
