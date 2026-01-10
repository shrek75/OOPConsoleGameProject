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


        //public Pos GetRenderPos()
        //{
        //    return _pos + (_dir * _speed) * 델타타임;
        //}
        //근데 이렇게하면 Update루프돌리고 Render왔을때 델타타임이 또 적용되는데 구조가..
        

        //방향
        Pos _dir;

        //속력
        double _speed;

        //크기
        double _radius;



        public abstract void Update();
        public abstract void Render();

        
    }
}
