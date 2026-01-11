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
        static readonly string[] _buffer;
        static int _index = 0;
        static bool _fill = false;            // 삭제없음ㅋ 그냥 한번다차면 true
        public static bool _enable = false;   // 로그 찍기 켜기/끄기
        static readonly int consolePosX = 40; // 로그출력할 X위치
        static readonly int consolePosY = 0;  // 로그출력할 Y위치 시작점
        const int SIZE = 20;                  // 링버퍼사이즈 겸 Y출력범위

        public static int Capacity => _buffer.Length;

        static Log()
        {
            _buffer = new string[SIZE];
        }

        // 로그 추가
        public static void Push(string log)
        {
            _buffer[_index] = log;
            _index = (_index + 1) % _buffer.Length;

            if (_index == 0)
                _fill = true;

            if(_enable)PrintLog();
        }

        // 순서대로 출력
        private static void PrintLog()
        {
            int count = _fill ? _buffer.Length : _index;
            //한번 꽉차면 어디부터 시작할지
            int start = _fill ? _index : 0;

            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(consolePosX, consolePosY + i);
                Console.Write(_buffer[(start + i) % _buffer.Length]);
            }

        }
    }
}
