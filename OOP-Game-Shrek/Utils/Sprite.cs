using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Utils
{
    // 객체의 외형과 크기를 나타내는 클래스
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

        
        public void Render(Pos pos)
        {
            // 객체의 좌표가 정중앙을 표현하고있으니 왼쪽상단으로 맞추는 작업.
            double firstX = pos._x - _sizeX / 2 + 0.5;
            double firstY = pos._y - _sizeY / 2 + 0.5;

            // 그 다음 콘솔의 위치좌표는 정수밖에없으니까 반올림할게.
            int x = (int)Math.Round(firstX, MidpointRounding.AwayFromZero); 
            int y = (int)Math.Round(firstY, MidpointRounding.AwayFromZero);

            ConsoleManager.Draw(x,y, _data);
        }
    }
}
