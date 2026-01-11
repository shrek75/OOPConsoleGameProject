using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    // 로그찍는 링버퍼 클래스
    internal static class Log
    {
        public enum LogType
        {
            INFO,
            WARN,
            ERROR,
        }

        static readonly (LogType,string)[] _buffer; 
        const int SIZE = 19;                  // 링버퍼사이즈 겸 Y출력범위
        static int _index = 0;
        static bool _fill = false;            // 삭제없음ㅋ 그냥 한번다차면 true
        public static bool _debugMode = false;   // 로그 찍기 켜기/끄기
        static readonly int consolePosX = 42; // 로그출력할 X위치
        static readonly int consolePosY = 0;  // 로그출력할 Y위치 시작점

        public static int Capacity => _buffer.Length;

        static Log()
        {
            _buffer = new (LogType, string)[SIZE];
        }

        // 로그 추가
        public static void Push(LogType type, string log)
        {
            _buffer[_index] = (type, log);
            _index = (_index + 1) % _buffer.Length;

            if (_index == 0)
                _fill = true;

        }

        //TimeManager에게 넘겨 1초마다 호출되게함
        public static void Print()
        {
            if (_debugMode) PrintLog();
            else PrintShrek();
        }


        //로그 Print
        private static void PrintLog()
        {
            Console.SetCursorPosition(consolePosX, consolePosY);
            Console.Write($"<{DateTime.Now.ToString("HH:MM:ss")}>  TPS: {TimeManager.nowTPS,3} FPS: {TimeManager.nowFPS,3}");

            int count = _fill ? _buffer.Length : _index;
            //한번 꽉차면 어디부터 시작할지
            int start = _fill ? _index : 0;

            //링버퍼 돌면서 로그찍기
            //안지워줘서 원래있던 문자열 남아잇는데 귀찮다 내일하자..
            for (int i = 1; i <= count; i++)
            {
                DateTime now = DateTime.Now;
                Console.SetCursorPosition(consolePosX, consolePosY + i);
                Console.Write($"{now.Hour}:{now.Minute:00}:{now.Second:00}:{now.Millisecond:000} ");
                if(_buffer[(start + i) % _buffer.Length].Item1 == LogType.WARN)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (_buffer[(start + i) % _buffer.Length].Item1 == LogType.ERROR)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{_buffer[(start + i) % _buffer.Length].Item1.ToString()}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(_buffer[(start + i) % _buffer.Length].Item2.ToString());

            }

        }

        public static void PrintShrek()
        {
            Console.SetCursorPosition(consolePosX, consolePosY);
            Console.Write($"<{DateTime.Now.ToString("HH:MM:ss")}>  TPS: {TimeManager.nowTPS,3} FPS: {TimeManager.nowFPS,3}");
            /**
            *       _____ __              __  
            *      / ___// /_  ________  / /__
            *      \__ \/ __ \/ ___/ _ \/ //_/
            *     ___/ / / / / /  /  __/ ,<   
            *    /____/_/ /_/_/   \___/_/|_|  
            *                                 
            */
            Console.SetCursorPosition(consolePosX, consolePosY + 1);
            Console.Write(@"   _____ __              __  ");
            Console.SetCursorPosition(consolePosX, consolePosY + 2);
            Console.Write(@"  / ___// /_  ________  / /__");
            Console.SetCursorPosition(consolePosX, consolePosY + 3);
            Console.Write(@"  \__ \/ __ \/ ___/ _ \/ //_/");
            Console.SetCursorPosition(consolePosX, consolePosY + 4);
            Console.Write(@" ___/ / / / / /  /  __/ ,<   ");
            Console.SetCursorPosition(consolePosX, consolePosY + 5);
            Console.Write(@"/____/_/ /_/_/   \___/_/|_|  ");

        }
    }
}
