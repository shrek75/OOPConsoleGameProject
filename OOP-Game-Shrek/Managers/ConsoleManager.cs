using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal static class ConsoleManager
    {
        const int X = 40; // console창 X축 사이즈
        const int Y = 20; // console창 Y축 사이즈

        static char[,] _buffer = new char[Y, X]; // console창에 출력할 내용을 담는 버퍼

        static ConsoleManager()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(X, Y);
            Console.SetBufferSize(X, Y);
            Console.Clear();
        }

        //버퍼의 내용 출력
        public static void Flip()
        {
            for(int i=0; i < Y; i++)
                for(int j=0; j < X; j++)
                    Console.Write(_buffer[i, j]);
        }

        //버퍼 클리어
        public static void BufferClear()
        {
            for (int i = 0; i < Y; i++)
                for (int j = 0; j < X; j++)
                    _buffer[i, j] = '\0';
        }

        //버퍼에 그리기
        public static void Draw(int x, int y, char c)
        {
            if (x < 0 || x > X - 1 || y < 0 || y > Y - 1)
                return;

            _buffer[y,x] = c;
        }

    }
}
