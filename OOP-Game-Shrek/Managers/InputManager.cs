using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    // User Input을 담당하는 클래스
    // GetAsyncKeyState()가 짱이네
    internal static class InputManager
    {

        // Poll()마다 inputKey를 담을 hashSet 
        static HashSet<ConsoleKey> _keys = new HashSet<ConsoleKey>();
        // readonly hashSet
        public static IReadOnlyCollection<ConsoleKey> Keys { get { return _keys; } }

        // 입력한 키가 있으면 _keys에 넣어준다.
        public static void Poll()
        {
            //이전 Key들 지워줌
            _keys.Clear();

            if ((GetAsyncKeyState(VK.Up) & 0x8000) != 0)
                _keys.Add(ConsoleKey.UpArrow);
            if ((GetAsyncKeyState(VK.Down) & 0x8000) != 0)
                _keys.Add(ConsoleKey.DownArrow);
            if ((GetAsyncKeyState(VK.Left) & 0x8000) != 0)
                _keys.Add(ConsoleKey.LeftArrow);
            if ((GetAsyncKeyState(VK.Right) & 0x8000) != 0)
                _keys.Add(ConsoleKey.RightArrow);

            if ((GetAsyncKeyState(VK.L) & 0x8000) != 0)
                _keys.Add(ConsoleKey.L);

            if ((GetAsyncKeyState(VK.Space) & 0x8000) != 0)
                _keys.Add(ConsoleKey.Spacebar);
            if ((GetAsyncKeyState(VK.Esc) & 0x8000) != 0)
                _keys.Add(ConsoleKey.Escape);
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);
    }
    public static class VK
    {
        public const int Left = 0x25;
        public const int Up = 0x26;
        public const int Right = 0x27;
        public const int Down = 0x28;

        public const int Space = 0x20;
        public const int Esc = 0x1B;

        public const int L = 0x4C;
    }
}
