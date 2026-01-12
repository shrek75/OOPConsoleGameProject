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
        //아니 콘솔출력 기본이 한글자를 가로의 2배가 세로가 되기때문에 
        // 시각적 만족감을 위해서 글자마다 X축을 2배로 출력해야겠음.
        // 이모지는 그냥 출력하면되는거고 기본문자를 빈칸을하나 더출력하냐/ 하나더복사하냐인데 하나더복사로 가보자

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
                    // 일반 16비트문자일경우
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
        public static void Draw(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
        {
            //x는 출력할때 2배
            x = x * 2;

            if (x < 0 || x + 1 > conX - 1 || y < 0 || y > conY - 1)
                return;

            _buffer[y,x] = (c,color);
            //X+1칸으로 복사해서 그려줌!!!!!!!!!!!!!
            _buffer[y, x+1] = (c, color);

        }

        //버퍼에 그리기2
        public static void Draw(int x, int y, char[,] arr)
        {
            //x는 출력할때 2배
            x = x * 2;

            if (arr == null) return;

            int sizeY = arr.GetLength(0);
            int sizeX = arr.GetLength(1);

            //이거 범위를 객체중심기준으로 바꿔야겠다. 걸쳐있어도 보이게
            // 다음에 바꾸자..
            if (x < 0 || x + sizeX * 2 > conX  || y < 0 || y + sizeY > conY)
                return;

            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                {
                    _buffer[y + i, x + j * 2] = (arr[i, j], ConsoleColor.White);
                    //X+1칸으로 복사해서 그려줌!!!!!!!!!!!!!
                    _buffer[y + i, x + j * 2 + 1] = (arr[i, j], ConsoleColor.White);
                }
        }

        //버퍼에 그리기3 (arr은 이모지용) (arr은 일단 이모지만들어온다는가정)
        public static void Draw(int x, int y, string[,] arr)
        {
            //x는 출력할때 2배
            x = x * 2;

            if (arr == null) return;

            int sizeY = arr.GetLength(0);
            int sizeX = arr.GetLength(1);

            //이거 범위를 객체중심기준으로 바꿔야겠다. 걸쳐있어도 보이게
            // 다음에 바꾸자..
            if (x < 0 || x + sizeX * 2 > conX || y < 0 || y + sizeY > conY)
                return;

            //string도 똑같이 넣고 출력만 잘해주는걸로
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                {
                    _buffer[y + i, x + j * 2] = (arr[i, j][0], ConsoleColor.White);
                    _buffer[y + i, x + j * 2 + 1] = (arr[i, j][1], ConsoleColor.White);

                }
        }

    }
}
