using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Scenes
{
    //SceneManager가 가장 먼저 활성화하는 Scene
    internal class SFirstScene : BaseScene
    {
        public SFirstScene()
        {
            SceneManager.ChangeScene<STitle>();
        }
    }
}
