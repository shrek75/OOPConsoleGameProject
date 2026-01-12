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
            _INFO,
            _WARN,
            ERROR,
        }

        static readonly (LogType,string)[] _buffer; //튜플로 가자
        const int SIZE = 23;                  // 링버퍼사이즈 겸 Y출력범위
        static int _index = 0;
        static bool _full = false;            // 삭제없음ㅋ 그냥 한번다차면 true
        static readonly int consolePosX = 84; // 로그출력할 X위치
        const int consoleMaxX = 140;          // 로그출력 X위치 끝지점    
        static readonly int consolePosY = 0;  // 로그출력할 Y위치 시작점
        private static bool _debugMode = false;   // 로그 찍기 켜기/끄기
        public static bool DebugMode
        {
            get { return _debugMode; } 
            set 
            {
                _debugMode = value;
                PrintEmpty();
            }
        }
        // keystate 0x0001왤캐 씹힘
        public static bool modeFlag = false;


        static Log()
        {
            _buffer = new (LogType, string)[SIZE];
        }

        // 로그 추가
        public static void Push(LogType type, string log)
        {
            DateTime now = DateTime.Now;
            string date = $"[{now.Hour:00}:{now.Minute:00}:{now.Second:00}:{now.Millisecond:000}] ";

            // 튜플배열로 logtype, log 둘다 담아주기
            _buffer[_index] = (type, date+log);
            //링버퍼라 index 계산
            _index = (_index + 1) % _buffer.Length;

            if (_index == 0)
                _full = true;

        }

        //TimeManager에게 넘겨 1초마다 호출되게함
        public static void Print()
        {
            if (_debugMode) PrintLog();
            else PrintShrek();
        }


        //디버그모드 ON, Print
        private static void PrintLog()
        {
            Console.SetCursorPosition(consolePosX, consolePosY);
            Console.Write($"< Debug[ ON] >  TPS: {TimeManager.nowTPS,3} FPS: {TimeManager.nowFPS,3}");

            int count = _full ? _buffer.Length : _index;
            //한번 꽉차면 어디부터 시작할지 
            int start = _full ? _index : 0;

            //링버퍼 돌면서 로그찍기
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(consolePosX, consolePosY + i + 1);
                //Log 종류 출력
                if(_buffer[(start + i) % _buffer.Length].Item1 == LogType._WARN)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (_buffer[(start + i) % _buffer.Length].Item1 == LogType.ERROR)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{_buffer[(start + i) % _buffer.Length].Item1.ToString()}] ");
                //Log 내용 출력
                Console.ForegroundColor = ConsoleColor.White;
                string tmp = _buffer[(start + i) % _buffer.Length].Item2;
                int strSize = consoleMaxX - consolePosX + 1;
                if (tmp.Length > strSize) tmp = tmp.Substring(0, strSize);
                else tmp = tmp.PadRight(strSize);
                Console.Write(tmp);
                
            }
            PrintHardCodingTeduri();



        }

        //디버그모드 OFF, Print
        public static void PrintShrek()
        {
            Console.SetCursorPosition(consolePosX, consolePosY);
            Console.Write($"< Debug[OFF] >  TPS: {TimeManager.nowTPS,3} FPS: {TimeManager.nowFPS,3}");
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
            Console.SetCursorPosition(consolePosX, consolePosY + 7);
            Console.Write("이동 : 방향키    공격 : 스페이스바");
            Console.SetCursorPosition(consolePosX, consolePosY + 9);
            Console.Write("[L] 을 눌러 디버그모드 ON/OFF 전환");


            PrintHardCodingTeduri();

        }

        private static void PrintEmpty()
        {
            string empty = new string(' ', 60);
            for(int i=1; i<= SIZE; i++)
            {
                Console.SetCursorPosition(consolePosX, consolePosY + i);
                Console.WriteLine(empty);
            }
        }

        private static void PrintHardCodingTeduri()
        {
            //아 귀찮아 하드코딩간다
            for (int i = 0; i < 24; i++)
            {
                Console.SetCursorPosition(80, i);
                Console.Write("🕳️");
            }
            Console.SetCursorPosition(0, 24);
            Console.Write("🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️🕳️");
        }
    }
}
