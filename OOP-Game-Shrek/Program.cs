using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log._enable = false;
            TimeManager.FuncBySec = Log.PrintShrek;
            while (SceneManager.Run());
        }
    }
}
