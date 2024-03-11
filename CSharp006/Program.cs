using System.Threading.Channels;

namespace CSharp006
{
    internal class Program
    { 
        /*
        예외처리
        프로그램 도중 발생하는 의도하지 않은 상황을 처리하는 방법
        try : 실행 코드 
        catch : 발생한 예외를 처리하는 블록
         */
        
        static void Main(string[] args)
        {
            //int[] arr = new int[3]{ 1,2,3};

            //// IndexOutOfRangeException
            //for (int i = 0; i<4; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            //// 정상적인 종료라면 여기까지 와야함 
            //Console.WriteLine("???");

            //try // 돌아가다가
            //{
            //    // 실행하려는 코드
            //    // ㄴ 예외가 일어나지 않을경우의 실행되어야 할 코드
            //}
            //catch (Exception)
            //{
            //    // 예외가 발생했을때 처리할 코드가
            //    // ㄴ 예외가 던져지면 여기서 받음
            //    // ㄴ catch는 try에서 던질 객체와 형식이 동일해야한다
            //    // ㄴ 만약 try에서 여러 종류의 예외를 던질 가능성이 있다면 catch도 여러개 있어야함  
            //}

            //int[] arr2 = new int[3] {1, 2, 3 };
            //try
            //{
            //    for(int i =0; i<4; i++)
            //    {   
            //        // 배열크기의 -1을 벗어나면 예외 발생 -> 아래 e로 던진다.
            //        Console.WriteLine(arr2[i]);
            //    }
            //}
            //catch(IndexOutOfRangeException e)
            //{
            //    Console.WriteLine($"{e.Message}");
            //}

            //try
            //{
            //    Console.Write("숫자를 입력해라 : ");
            //    string input = Console.ReadLine();
            //    int value = int.Parse(input);
            //    int[] array = new int[value];

            //    array[10] = 10;
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("입력값이 정수로 변환이 불가능한 경우 예외 발생");
            //}
            //catch(IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("입력값이 10 이하인 경우 인덱스 접근이 불가하므로 예외 발생");
            //}
            // throw

            try
            {
                int[] array = { 1, 3, 5, 7, 9 };
                int index = Array.IndexOf(array, 8);

                if(index <0)
                {
                    throw new InvalidOperationException();

                    array[index] = 0;
                }
            }
            catch(InvalidOperationException ex2)
            {
                Console.WriteLine(ex2.Message);
                Console.WriteLine("배열에서 원하는 값을 찾지 못함");
            }
        }
    }
}
