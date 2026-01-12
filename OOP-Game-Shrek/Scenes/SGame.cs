using OOP_Game_Shrek.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Scenes
{
    internal class SGame : BaseScene
    {
        public SGame()
        {
            ObjectManager.AddObject(new MPoop(new Pos(11, 4)));
            ObjectManager.AddObject(new MPoop(new Pos(25, 4)));
            ObjectManager.AddObject(new MRamen(new Pos(3, 5)));
        }
    }
}
