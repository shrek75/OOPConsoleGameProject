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
        public Pos Pos { get { return _pos; } }

        //방향
        protected Pos _dir;

        //속력
        protected double _speed;

        //객체의 외형과 크기
        public Sprite _sprite;

        //Render를 위한 위치반환
        protected Pos RenderPos { get { return _pos + (_dir * _speed) * TimeManager.DeltaTime; } }

        //Update에서 오브젝트위치 갱신용 Move
        public virtual void Move()
        {
            _pos = _pos + (_dir * _speed) * TimeManager.LogicTime;
        }

        public abstract void Update();

        //BaseObject 기본 Render
        public virtual void Render()
        {
            _sprite?.Render(RenderPos);
        }

        
    }
}
