using OOP_Game_Shrek.Objects.Skills;
using OOP_Game_Shrek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Game_Shrek.Objects
{
    internal class Player : BaseObject, ICollision
    {
        public Player(Pos pos)
        {
            HP = 100;
            _pos = pos;
            base._speed = 10;
            _sprite = new Sprite(new string[,]
                {
                    {"😀"}
                });
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Update()
        {
            //기본스킬
            if (InputManager.Keys.Contains(ConsoleKey.Spacebar))
            {
                Pos skillPos = _pos + _lastLookDir * 2;
                ObjectManager.AddObject(new SSwordBaseAttack(skillPos));
            }

            // 입력한 방향키에따라 player 방향 바꿔주기
            Pos newDir = new Pos(0, 0);
            if (InputManager.Keys.Contains(ConsoleKey.UpArrow))
                newDir += Pos.Up;
            if (InputManager.Keys.Contains(ConsoleKey.DownArrow))
                newDir += Pos.Down;
            if (InputManager.Keys.Contains(ConsoleKey.RightArrow))
                newDir += Pos.Right;
            if (InputManager.Keys.Contains(ConsoleKey.LeftArrow))
                newDir += Pos.Left;
            Dir = newDir;
            Move();

            
        }

        public void OnCollision(BaseObject otherObj)
        {
            //
        }

        

    }

   

}
