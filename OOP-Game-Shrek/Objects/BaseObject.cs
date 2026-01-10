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
        //기존위치
        Pos _pos;

        //방향
        Pos _dir;

        //속력
        double _speed;

        //크기
        //double _radius;

        //객체의 외형?모양?
        private Sprite _sprite;

        //Render를 위한 위치반환
        public Pos GetRenderPos()
        {
            return _pos + (_dir * _speed) * TimeManager.DeltaTick;
        }

        public abstract void Update();
        public abstract void Render();

        
    }
}
