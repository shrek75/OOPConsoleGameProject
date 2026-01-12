using OOP_Game_Shrek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects.Skills
{
    internal abstract class BaseSkill : BaseObject, ICollision
    {
        //데미지랑 타이머도 있어야하는데
        protected double _damage = 20;
        protected int _lifeTime = (int)(2 * TimeManager.GAME_TPS); 

        public BaseSkill(Pos pos)
        {
            _isInvincible = true;
            _pos = pos;
            //_sprite는 하위클래스에서 구현
        }

        public abstract void OnCollision(BaseObject otherObj);

        public override void Update()
        {
            _lifeTime--;
            if (_lifeTime < 0)
                ObjectManager.DeleteObject(this);

        }
    }
}
