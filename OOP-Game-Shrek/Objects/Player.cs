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
            _pos = pos;
            base._speed = 3;
            _sprite = new Sprite(new char[,] { { 'P' } });
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Update()
        {
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
            _dir = newDir;

            

            Move();
            Log.Push(Log.LogType.INFO,$"[{_dir._x}][{_dir._y}]");
        }

        public void OnCollision(BaseObject otherObj)
        {
            //
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

    }
}
