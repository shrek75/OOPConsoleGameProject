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
        protected Pos _pos = new Pos(10,10);
        public Pos Pos { get { return _pos; } }

        //현재 진행 방향
        private Pos _dir = new Pos(0, 0);
        protected Pos Dir
        {
            get { return _dir; } 
            set
            {
                _dir = value;
                //멈췄을때 마지막으로 진행했던 방향을 기억
                if(_dir._x !=0 || _dir._y != 0)
                    _lastLookDir = _dir;
            }
        }

        //마지막으로 바라봤던 방향
        protected Pos _lastLookDir = new Pos(0,0);

        //속력
        protected double _speed = 0;

        //객체의 외형과 크기
        public Sprite _sprite;

        //무적여부
        protected bool _isInvincible = false;

        //체력
        private double _hp = 1000;
        public double HP
        {
            get { return _hp; }
            set
            {
                //무적이면 HP건들이지마
                if(!_isInvincible) _hp = value;
                if (_hp <= 0)
                {
                    _IsDead = true;
                }
            }
        }

        //죽었는지
        private bool _IsDead = false;
        public bool IsDead { get { return _IsDead; } }

        public abstract void Update();

        //BaseObject 기본 Render
        public virtual void Render()
        {
            _sprite?.Render(RenderPos);
        }

        //Render를 위한 위치반환
        protected Pos RenderPos { get { return _pos + (Dir * _speed) * TimeManager.DeltaTime; } }

        //Update에서 오브젝트위치 갱신용 Move
        public virtual void Move()
        {
            _pos = _pos + (Dir * _speed) * TimeManager.LogicTime;
        }

        public virtual void Damage(double attackPower)
        {
            HP -= attackPower;
        }

        public void DrawHP()
        {
            ConsoleColor color;
            //HP출력의 색을 10단위로 정함
            int hp = (int)HP / 10;
            switch(hp)
            {
                case 0:
                case 1:
                case 2:
                    color = ConsoleColor.Red;
                    break;
                case 3:
                case 4:
                case 5:
                    color = ConsoleColor.Yellow;
                    break;
                case 6:
                case 7:
                case 8:
                    color = ConsoleColor.Blue;
                    break;
                default:
                    color = ConsoleColor.Green;
                    break;
            }

            //체력바 떠있는 위치 정하기
            Pos hPPos = _sprite.RetLeftTopPos(RenderPos) + new Pos(-1, -1);
            ConsoleManager.Draw((int)hPPos._x, (int)hPPos._y, '▬', color);
        }

        
    }
}
