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
        const int LogSize = 60; //로그출력용 추가 X축 사이즈

        static (char c,ConsoleColor color)[,] _buffer = new (char, ConsoleColor)[conY, conX]; // console창에 출력할 내용을 담는 버퍼

        // 생성자에서 초기화 작업
        static ConsoleManager()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
                {
                    char c = _buffer[i, j].c;
                    //32비트짜리 문자Low인지?
                    if (char.IsLowSurrogate(c))
                        continue;

                    //32비트문자 High인지?
                    if (char.IsHighSurrogate(c) && j + 1 < conX)
                    {
                        char next = _buffer[i, j+1].c;

                        if (char.IsLowSurrogate(next))
                        {
                            Console.Write($"{c}{next}"); //char 2개합쳐서 string만들기
                            j++; // 1칸 더 추가
                            continue;
                        }
                    }
                    // char는 색기능추가했기때문에 색깔에맞춰 출력.
                    if (_buffer[i, j].color != ConsoleColor.White)
                    {
                        Console.ForegroundColor = _buffer[i, j].color;
                        Console.Write(c);
                        //여기코드들 프레임 너무떨어져서 조건문 달았음.
                        Console.ResetColor();
                    }
                    else Console.Write(c);
                }

                Console.WriteLine();
            }


            BufferClear();
        }

        //버퍼 클리어
        private static void BufferClear()
        {
            for (int i = 0; i < conY; i++)
                for (int j = 0; j < conX; j++)
                    _buffer[i, j] = (' ',ConsoleColor.White);
        }

        //버퍼에 그리기
        public static void Draw(int x, int y, char c, ConsoleColor color)
        {
            if (x < 0 || x > conX - 1 || y < 0 || y > conY - 1)
                return;

            _buffer[y,x] = (c,color);
        }

        //버퍼에 그리기2
        public static void Draw(int x, int y, char[,] arr)
        {
            if (arr == null) return;

            int sizeY = arr.GetLength(0);
            int sizeX = arr.GetLength(1);

            //이거 범위를 객체중심기준으로 바꿔야겠다. 걸쳐있어도 보이게
            // 다음에 바꾸자..
            if (x < 0 || x + sizeX > conX  || y < 0 || y + sizeY > conY)
                return;

            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    _buffer[y + i, x + j] = (arr[i, j], ConsoleColor.White);
        }

        //버퍼에 그리기3 (arr은 이모지용)
        public static void Draw(int x, int y, string[,] arr)
        {
            if (arr == null) return;

            int sizeY = arr.GetLength(0);
            int sizeX = arr.GetLength(1) * 2; //이모지는 X축 2칸

            //이거 범위를 객체중심기준으로 바꿔야겠다. 걸쳐있어도 보이게
            // 다음에 바꾸자..
            if (x < 0 || x + sizeX > conX || y < 0 || y + sizeY > conY)
                return;

            //string도 char처럼 넣고 출력만 잘해주는걸로
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                {
                    // 16비트문자 , 32비트문자 둘다고려해야함 
                    string s = arr[i, j / 2];
                    char c;
                    // Length가 2면 뒷자리도 그대로 넣어줌
                    if (s != null && j % 2 < s.Length)
                        c = s[j % 2];
                    // Length가 1이면 뒷자리는 빈칸으로
                    else c = ' ';

                    _buffer[y + i, x + j] = (c, ConsoleColor.White);
                }
        }

    }
}
