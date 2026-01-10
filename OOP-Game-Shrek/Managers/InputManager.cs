using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal static class InputManager
    {
        //어떻게 만들지...

        static ConsoleKeyInfo _key;
        static HashSet<ConsoleKeyInfo> _keys = new HashSet<ConsoleKeyInfo>();
        public static IReadOnlyCollection<ConsoleKeyInfo> Keys { get { return _keys; } }

        public static void Poll()
        {
            while(Console.KeyAvailable)
            {
                _key = Console.ReadKey();
                _keys.Add(_key);
            }
        }
        public static void Clear()
        {
            _keys.Clear();
        }

    }
}
