using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Utils
{
    internal class Sprite
    {
        private char[,] _data;
        public int _sizeX { get; }
        public int _sizeY { get; }

        // 출력할 객체의 모양을 char[,]형으로 넘겨주어 생성
        public Sprite(char[,] spriteArr)
        {
            _data = spriteArr;
            _sizeX = spriteArr.GetLength(1);
            _sizeY = spriteArr.GetLength(0);
        }

        //객체의 좌표가 모양의 왼쪽상단을 표현한다고 정함.
        public void Render(Pos pos)
        {
            //콘솔의 위치좌표는 정수밖에없으니까 반올림할게.
            int x = (int)Math.Round(pos.X, MidpointRounding.AwayFromZero); 
            int y = (int)Math.Round(pos.Y, MidpointRounding.AwayFromZero);

            ConsoleManager.Draw(x,y, _data);
        }
    }
}
