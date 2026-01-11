using OOP_Game_Shrek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal abstract class BaseObject
    {
        //객체의 정중앙 위치
        protected Pos _pos;

        //방향
        protected Pos _dir;

        //속력
        protected double _speed;

        //객체의 외형과 크기
        protected Sprite _sprite;

        //Render를 위한 위치반환
        public Pos RenderPos { get { return _pos + (_dir * _speed) * TimeManager.DeltaTick; } }

        public abstract void Update();
        public abstract void Render();

        
    }
}
