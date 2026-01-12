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
        private char[,] _charData;  //char형문자로 외형을 나타날때
        private string[,] _strData; //string형문자로 외형을 나타낼때
        public int _sizeX { get; }
        public int _sizeY { get; }
        private bool strMode = false; //char형 string형 버전2개로 사용

        // 출력할 객체의 모양을 char[,]형으로 넘겨주어 생성
        public Sprite(char[,] spriteArr)
        {
            _charData = spriteArr;
            _sizeX = spriteArr.GetLength(1);
            _sizeY = spriteArr.GetLength(0);
        }

        // 출력할 객체의 모양을 string[,]형으로 넘겨주어 생성 (char1개로 못담는 이모티콘용)
        public Sprite(string[,] spriteArr)
        {
            _strData = spriteArr;
            _sizeX = spriteArr.GetLength(1);
            _sizeY = spriteArr.GetLength(0);
            strMode = true;
        }

        //객체의 외형을 그림
        public void Render(Pos pos)
        {
            Pos p = RetLeftTopPos(pos);
            int x = (int)p._x;
            int y = (int)p._y;

            if (strMode) ConsoleManager.Draw(x, y, _strData);
            else ConsoleManager.Draw(x, y, _charData);
        }

        //객체의 크기가 클때, 화면상 객체의 왼쪽윗부분을 반환.
        public Pos RetLeftTopPos(Pos pos)
        {
            Pos retPos;

            // 객체의 좌표가 정중앙을 표현하고있으니 왼쪽상단으로 맞추는 작업.
            double firstX = pos._x - _sizeX / 2.0 + 0.5;
            double firstY = pos._y - _sizeY / 2.0 + 0.5;

            // 그 다음 콘솔의 위치좌표는 정수밖에없으니까 반올림해서 보내줄게.
            retPos._x = (int)Math.Round(firstX, MidpointRounding.AwayFromZero);
            retPos._y = (int)Math.Round(firstY, MidpointRounding.AwayFromZero);

            return retPos;
        }
    }
}
