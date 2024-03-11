// 1. 델리게이트체인을 활용한 캐릭터 스킬을 만드세요
// ㄴ 플레이어가 공격한다.
// ㄴ 00 스킬이펙트!
// ㄴ 00 스킬이펙트!
// ㄴ 00 스킬이펙트! 다른 스킬들
// ㄴ 플레이어가 공격을 종료합니다

namespace CSharp006
{
    public class Player
    {
        public event Action GetAttack;

        public void Attack()
        {
            Console.WriteLine("플레이어가 공격한다");

            if (GetAttack != null) GetAttack();
        }
    }

    public class UI
    {
        public void UpdateUI()
        {
            Console.WriteLine("UI창에 스킬을 업뎃한다");
        }
    }

    public class cBuff
    {
        public void Buff() { Console.WriteLine("버프발동 이펙트"); }
    }
    public class cAtkBuff : cBuff
    {   
        public void AtkBuff() 
        { 
            base.Buff();
            Console.WriteLine("공격력 증가 버프 이펙트"); 
        }
    }

    public class SkillFire
    {
        public void Fire() { Console.WriteLine("화염계통 스킬 이펙트"); }
    }

    public class SkillFireBall : SkillFire
    {
        public void FireBall()
        {
            base.Fire();
            Console.WriteLine("파이어볼 스킬 이펙트!");
        }
    }

    public class cAttackEnd
    {
        public void AttackEnd() { Console.WriteLine("플레이어가 공격을 종료합니다"); }
    }
    

    internal class ex
    {
        static void Main(string[] args) 
        {
            Player player = new Player();
            UI ui = new UI();
            SkillFireBall fireball = new SkillFireBall();
            cAtkBuff atkbuff = new cAtkBuff();
            cAttackEnd atkend = new cAttackEnd();

            // 이벤트에 반응할 객체의 메서드 추가
            player.GetAttack += ui.UpdateUI;
            player.GetAttack += atkbuff.AtkBuff;
            player.GetAttack += fireball.FireBall;
            player.GetAttack += atkend.AttackEnd;
           
            player.Attack();
        }
    }
}
