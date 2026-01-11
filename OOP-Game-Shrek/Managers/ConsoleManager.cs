using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Game_Shrek
{
    // 콘솔 출력을 담당하는 클래스
    internal static class ConsoleManager
    {
        const int conX = 40; // console창 X축 사이즈
        const int conY = 20; // console창 Y축 사이즈
        const int LogSize = 40; //로그출력용 추가 X축 사이즈

        static char[,] _buffer = new char[conY, conX]; // console창에 출력할 내용을 담는 버퍼

        // 생성자에서 초기화 작업
        static ConsoleManager()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(conX+ LogSize, conY);
            Console.SetBufferSize(conX+ LogSize, conY);
            Console.Clear();
        }

        //버퍼의 내용 출력
        public static void Flip()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < conY; i++)
            {
                for (int j = 0; j < conX; j++)
                    Console.Write(_buffer[i, j]);
                Console.WriteLine();
            }
            BufferClear();
        }

        //버퍼 클리어
        private static void BufferClear()
        {
            for (int i = 0; i < conY; i++)
                for (int j = 0; j < conX; j++)
                    _buffer[i, j] = ' ';
        }

        //버퍼에 그리기
        public static void Draw(int x, int y, char c)
        {
            if (x < 0 || x > conX - 1 || y < 0 || y > conY - 1)
                return;

            _buffer[y,x] = c;
        }

        //버퍼에 그리기2
        public static void Draw(int x, int y, char[,] arr)
        {
            if (arr == null) return;

            int sizeY = arr.GetLength(0);
            int sizeX = arr.GetLength(1);

            if (x < 0 || x + sizeX > conX  || y < 0 || y + sizeY > conY)
                return;

            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    _buffer[y + i, x + j] = arr[i, j];
        }

    }
}
