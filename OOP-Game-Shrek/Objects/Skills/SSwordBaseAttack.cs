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
                new string[,] { { "💥" } }
                );
        }

        public override void OnCollision(BaseObject otherObj)
        {
            if(otherObj is Monster)
            {
                otherObj.Damage(_damage);
                if (otherObj.IsDead) ObjectManager.DeleteObject(otherObj);
            }
        }
    }
}
