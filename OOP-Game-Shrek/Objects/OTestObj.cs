using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class OTestObj : BaseObject
    {
        public override void Update()
        {
            
        }
        public override void Render()
        {
            Console.WriteLine("OTestObj 하이 ^_^");
            Console.WriteLine($"{this.GetHashCode()}");
        }

    }
}
