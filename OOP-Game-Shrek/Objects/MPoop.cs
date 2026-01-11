using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class MPoop : Monster
    {
        public MPoop(Pos pos)
        {
            // 위치
            _pos = pos;

            // 외형 
            char[,] s = new char[,] { { '♨' } };
            _sprite = new Utils.Sprite(s);

            // 속력
            _speed = 1.5;

            // 방향  아 player바라보게 방향바꿔줘야하는구나
            _dir = new Pos(1, 0);
   
        }
        
        


    }
}
