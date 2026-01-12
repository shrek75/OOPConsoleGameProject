using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class MPoop : Monster
    {
        public MPoop(Pos pos)
        {
            // 위치
            _pos = pos;

            // 외형 
            char[,] s = new char[,] { { '♨' } };
            _sprite = new Utils.Sprite(s);

            // 속력
            _speed = 2;

            // 방향
            Dir = new Pos(0, 0);

            // 몸박뎀쿨
            _bodyDamageCoolDown = (int)(3 * TimeManager.GAME_TPS);

            _bodyDamage = 30;
   
        }

        public override void Update()
        {
            
            //Player와의 거리가 10이하가 되면 추적상태 ON 
            if(_trackPlayer) Dir = ObjectManager.GetDirVectorToPlayer(this.Pos);
            else if(ObjectManager.GetDistanceToPlayer(this.Pos) < 10)
            {
                base._trackPlayer = true;
            }
            Move();

            //근데 이렇게하면 monster가 여러명을 못때려서 skill하나가 때린정보를 기억하고 개별적 쿨탐을 계산해야하는건가
            if(_bodyDamageUsable == false)
            {
                if (--_bodyDamageCalcuation == 0)
                {
                    //Log.Push(Log.LogType._WARN, $"쿨 ON");
                    _bodyDamageUsable = true;
                    _bodyDamageCalcuation = _bodyDamageCoolDown;
                }
            }
        }

        public override void OnCollision(BaseObject otherObj)
        {
            //플레이어 객체일경우
            if(otherObj is Player p)
            {
                if (_bodyDamageUsable)
                {
                    _bodyDamageUsable = false;

                    otherObj.Damage(this._bodyDamage);
                    if (otherObj.IsDead)
                    {
                        ObjectManager.DeletePlayer(p);
                        //Log.Push(Log.LogType._WARN, $"작동하나?");

                    }

                    Log.Push(Log.LogType.ERROR, $"{base._bodyDamage} 뎀지 주기!");
                    Log.Push(Log.LogType._INFO, $"player 체력 : [{p.HP}]");
                }
            }
        }

    }
}
