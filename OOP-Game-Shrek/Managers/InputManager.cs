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
        static Queue<ConsoleKeyInfo> _keys = new Queue<ConsoleKeyInfo>();

        public static void Test()
        {
            //if (Console.KeyAvailable == false) return;
            while(Console.KeyAvailable)
            {
                _key = Console.ReadKey();
                _keys.Enqueue(_key);
            }
        }
    }
}
