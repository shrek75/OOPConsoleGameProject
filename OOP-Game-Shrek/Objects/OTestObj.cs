using OOP_Game_Shrek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class OTestObj : BaseObject, ICollision
    {
        public OTestObj(Pos pos)
        {
            _pos = pos;
            _sprite = new Utils.Sprite(
                new char[,] {
                    { '#', '#', '#', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', '#', '#', '#' }});
           // Log.Push(Log.LogType.INFO,$"{this.GetHashCode()} 생성완료!");
        }

        public override void Update()
        {
            if(_pos._y == 3)
            {
                base._speed = 1.0;
                base.Dir = new Pos(1, 0);
              //  Log.Push(Log.LogType.WARN,$"{this.GetHashCode()} 오른쪽 움직임!");

            }
            if (_pos._y == 5)
            {
                base._speed = 1.0;
                base.Dir = new Pos(-1, 0);
              //  Log.Push(Log.LogType.ERROR,$"{this.GetHashCode()} 왼쪽 움직임!");
            }

            Move();
        }
        public override void Render()
        {
            base.Render();
        }

        public void OnCollision(BaseObject otherObj)
        {
            
        }
    }
}
