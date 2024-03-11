using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp006
{
    public class Player
    {
        public event Action onGetCoin;

        public void GetCoin()
        {
            Console.WriteLine("플레이어가 코인을 획득함!");

            if (onGetCoin != null) onGetCoin();
        }
    }

    public class UI
    {
        public void UpdateUI() { Console.WriteLine("UI창에 코인의 갯수를 갱신!"); }
    }
    public class SFX
    {
        public void CoinSound() { Console.WriteLine("코인을 획득한 사운드 재생"); }
    }
    public class VFX
    {
        public void CoinEffect() { Console.WriteLine("코인을 획득한 번쩍거리는 이펙트 효과 발생"); }
    }

    internal class re2
    {
        static void Main(string[] args)
        {
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
        }
    }
}
