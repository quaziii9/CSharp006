
namespace CSharp006
{
    public class Player
    {
        public event Action onGetCoin;

        public void GetCoin()
        {
            Console.WriteLine("플레이어가 코인을 획득함!");

            if(onGetCoin != null) onGetCoin();
        }
    }

    public class UI
    {
        public void UpdateUI()
        {
            Console.WriteLine("UI창에 코인의 갯수를 갱신!");
        }
    }
    public class SFX
    {
        public void CoinSound() { Console.WriteLine("코인을 획득한 사운드 재생"); }
    }
    public class VFX
    {
        public void CoinEffect()
        {
            Console.WriteLine("코인을 획득한 번쩍거리는 이펙트 효과 발생");
        }
    }

    public class EventSender
    {
        public Action onDelegate;
        public event Action onEvent;

        public void DelegatedCall()
        {
            if (onDelegate != null) onDelegate();
        }

        public void EventCall()
        {
            if (onEvent != null) onEvent(); 
        }
    }
    public class EventListener
    {
        public void func()
        {
            Console.WriteLine("호출");
        }
    }
    
    internal class event2
    {
        static void Main()
        {
            #region 코인
            Player player = new Player();
            UI ui = new UI();
            SFX sFX = new SFX();
            VFX vFX = new VFX();

            // 이벤트에 반응할 객체의 메서드 추가
            player.onGetCoin += ui.UpdateUI;
            player.onGetCoin += sFX.CoinSound;

            player.GetCoin();
            
            Console.WriteLine();
            // 이벤트 형식으로 코드를 수정하지 않고 이벤트시 반응할 객체를 추가가 가능하다
            player.onGetCoin += vFX.CoinEffect;
            player.GetCoin();

            Console.WriteLine();

            // 코드 수정없이 객체제거 가능 
            player.onGetCoin -= sFX.CoinSound;
            player.GetCoin();
            #endregion

            Console.WriteLine("======================================================");

            EventSender sender = new EventSender();

            EventListener listener1 = new EventListener();
            EventListener listener2 = new EventListener();
            EventListener listener3 = new EventListener();

            sender.onDelegate += listener1.func;
            sender.onDelegate += listener2.func;
            sender.onDelegate = listener3.func;
            // 델리게이트는 대입 연산이 가능 , 하지만 기존의 이벤트에 반응할 객체들이 초기화 되니 주의 

            sender.onEvent += listener1.func;
            sender.onEvent += listener2.func;
            // sender.onEvent = listener3.func;    // 이벤트는 대입 연산x, 객체들의 상황을 온전하게 유지 가능 


            // 델리게이트는 외부에서 호출 가능
            // 사건이 발생하지 않아도 이벤트 발생 가능 
            sender.onDelegate();


            // 이벤트는 클래스 외부에서 호출불가
            // 객체가 일련의 사건이 발생한 경우에만 내부에서 이벤트 발생 보장이 가능
            // public인데도 외부에서 호출이 불가능
            // sender.onEvent(); // error : 외부에서 호출불가
        }
    }
}
