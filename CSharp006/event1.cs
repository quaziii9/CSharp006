
namespace CSharp006
{
    // 이벤트 
    // 일련의 사건이 발생했다는~ 사실을 다른 객체한테 전달
    // 델리게이트 선언
    // 클래스 내에서 선언한 델리게이트 인스턴스를 event 한정자로 선언 
    // 이벤트 핸들러 작성
    // 이벤트 핸들러는 선언한 델리게이트와 일치하면 OK
    // 클래스의 인스턴스를 생성하고 이 객체의 이벤트에 이벤트 핸들러 등록
    // 이벤트가 발생하면 이벤트 핸들러가 호출
    // 델리게이트 : 직접 호출
    // 이벤트 : 직접적인 호출 X
    // 델리게이트와 이벤트 비교 찾아보기

    //1.
    delegate void EventHandler(string str);

    class EventTest
    {   //2.
        public event EventHandler eve;
    
        public void func(int num)
        {
            int temp = num % 10;
            if(temp!=0 && temp %3== 0)
            {
                // 3 ,6 ,9 로 끝날때마다 이벤트 발생
                eve($"{num}");
            }
        }
    }

    public delegate void MyDelegate();


    public class DelTest
    {
        public void MyFunc()
        {
            Console.WriteLine("델리게이트 메서드 호출");
        }
    }

    public delegate void MyEventHandler();
    public class EventTest01
    {
        public event MyEventHandler MyEvent;

        public void MyEventFunc()
        {
            Console.WriteLine("이벤트 발생");
        }
        public void MyEventHandlerFunc()
        {
            Console.WriteLine("이벤트 핸들러 호출");
        }
    }

    // 
    delegate int Calculate(int a, int b);

    internal class event1
    {
        public static void MyHandler(string str)
        {
            Console.WriteLine(str);
        }

        static void Main()
        {
            EventTest eventTest = new EventTest();
            eventTest.eve += new EventHandler(MyHandler);

            for(int i = 0; i<30; i++)
            {
                eventTest.func(i);
            }

            DelTest instance = new DelTest();

            MyDelegate myDelegate = new MyDelegate(instance.MyFunc);
            myDelegate();
            // 직접 호출이 가능 


            EventTest01 instance01 = new EventTest01();

            // instance01.MyEvnet(); 직접 이벤트 호출 불가능 
            // Event에 Event 핸들러를 등록해야 가능 += , -=
            // += : 이벤트에 반응할 객체의 추가할 함수 -> 참조 추가
            // -= : 이벤트에 반응할 객체의 제거할 함수 -> 참조 제거
            // 델리게이트는 콜백 용도
            // 이벤트는 이벤트대로 객체의 상태변화나 일련의 사건을 알리는 용도로만 사용

            Calculate cal;
            cal = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine("{0}", cal(3, 4));

            // 매개변수목록 => 식
            // => 기준으로 왼쪽에 있는 애들이 매개변수, 오른쪽은 식
            // => : 연산자 , 입력용
            // 람다식
            Calculate cal1 = (a, b) => a + b;
            Console.WriteLine("{0}",cal1(3,4));



            // 1. 델리게이트체인을 활용한 캐릭터 스킬을 만드세요
            // ㄴ 플레이어가 공격한다.
            // ㄴ 00 스킬이펙트!
            // ㄴ 00 스킬이펙트!
            // ㄴ 00 스킬이펙트! 다른 스킬들
            // ㄴ 플레이어가 공격을 종료합니다

            // Func : 결과를 반환하는 메서드 참조, Action 결과를 반환하지 않는 메서드 참조
            // Func, Action, : 정리 
            // 델리게이트와 이벤트 차이
        }
    }
}
