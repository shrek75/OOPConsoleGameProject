using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects.Skills
{
    internal class SSwordBaseAttack : BaseSkill
    {
        

        public SSwordBaseAttack(Pos pos) : base(pos)
        {
            _sprite = new Utils.Sprite(
                new string[,] { { "💥", "💥" }, { "💥", "💥" } }
                );
            _damage = 30;
            _maxTargetNums = 4;
        }

        public override void OnCollision(BaseObject otherObj)
        {
            //이미 타겟수의 Max만큼 때렸다면 return
            if (_targets.Count >= _maxTargetNums) return;

            if(otherObj is Monster)
            {
                //이미 맞은 몬스터가 아니라면
                if (!_targets.Contains(otherObj))
                {
                    //targets에 넣고
                    _targets.Add(otherObj);

                    otherObj.Damage(_damage);
                    if (otherObj.IsDead) ObjectManager.DeleteObject(otherObj);

                    Log.Push(Log.LogType._WARN, $"HP : {otherObj.HP}");
                }
            }
        }
    }
}
